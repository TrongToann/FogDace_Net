using Application.Abstractions;
using Application.Data;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.Service;
using Domain.Abstraction.Repositories;
using Domain.Exceptions.Auth;
using static Contract.Service.Auth.Command;

namespace Application.Features.V1.Command.Auth
{
    public class LogoutCommandHandler : ICommandHandler<Logout, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenRepository _tokenRepository;
        private readonly ITokenUsedRepository _tokenUsedRepository;

        public LogoutCommandHandler(IUnitOfWork unitOfWork, ITokenRepository tokenRepository, ITokenUsedRepository tokenUsedRepository)
        {
            _unitOfWork = unitOfWork;
            _tokenRepository = tokenRepository;
            _tokenUsedRepository = tokenUsedRepository;
        }

        public async Task<Result<BaseResponse>> Handle(Logout request, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.FindSingleAsync(x => x.Account_id == request.Account_id);
            if (token == null) throw new AuthBadRequest();
            List<Domain.Entities.TokenUsed> tokens = _tokenUsedRepository
                .GetAll(x => x.TokenId == token.Id).ToList();
            _tokenUsedRepository.RemoveMultiple(tokens);
            _tokenRepository.Remove(token);
            await _unitOfWork.SaveChangesAsync();
            var response = new BaseResponse();
            response.Success = true;
            response.Message = "Logout Successfully!";
            response.Errors = [];
            return response;
        }
    }
}
