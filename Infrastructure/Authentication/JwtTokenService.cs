using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Application.Abstractions;
using Infrastructure.DependencyInjection.Options;
using Domain.Exceptions.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
namespace Infrastructure.Authentication
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtOption jwtOption = new JwtOption();
        private readonly HttpRequest request;
        public JwtTokenService(IConfiguration configuration)
        {
            configuration.GetSection(nameof(JwtOption)).Bind(jwtOption);
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SecretKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtOption.Issuer,
                    audience: jwtOption.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(jwtOption.ExpireMin),
                    signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public Guid GetClaimsAccountIdFromToken(HttpRequest request)
        {
            string token = GetAccessTokenFromRequest(request);
            var claims = this.GetClaimsPrincipalFromToken(token);
            string account_id = claims.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (account_id.IsNullOrEmpty()) throw new BadRequestError();
            Guid accountId = ParseTokenIntoGuidFromString(account_id);
            return accountId;
        }
        public Guid ParseTokenIntoGuidFromString(string account_id)
        {
            Guid accountId;
            if (!Guid.TryParse(account_id, out accountId)) throw new BadRequestError();
            return accountId;
        }
        public ClaimsPrincipal GetClaimsPrincipalFromToken(string token)
        {
            var Key = Encoding.UTF8.GetBytes(jwtOption.SecretKey);
            var tokenValidateParameter = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOption.Issuer,
                ValidAudience = jwtOption.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidateParameter, out SecurityToken securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if(jwtSecurityToken == null || 
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)){
                    throw new SecurityTokenException("Invalid Token");
                };
            return principal;
        }
        private string GetAccessTokenFromRequest(HttpRequest request)
        {
            CheckNullHeader(request);
            string header = GetHeaderAuthorizeIfFormatIsValid(request);
            string token = header.Substring("Bearer ".Length);
            return token;
        }
        private string GetHeaderAuthorizeIfFormatIsValid(HttpRequest request)
        {
            string authorizationHeader = request.Headers.Authorization.FirstOrDefault();
            if (authorizationHeader is null || authorizationHeader?.StartsWith("Bearer ") is false)
                throw new UnauthorizedAccessException("Missing authorization token");
            return authorizationHeader;
        }
        private void CheckNullHeader(HttpRequest request)
        {
            if (request.Headers.Authorization.Count < 0)
                throw new UnauthorizedAccessException("Missing authorization token");
        }
    }
}
