using Contract.Service.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Infrastructure.Authentication
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public int RoleName { get; set; }
        public int ActionValue { get; set; }
        public CustomAuthorizeAttribute(int roleName, int actionValue) : base(typeof(CustomAuthorizeAttribute))
        {
            RoleName = roleName;
            ActionValue = actionValue;
            Arguments = new object[] { RoleName, ActionValue };
        }
    }
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        public CustomAuthorizeFilter(int rolename, int actionValue)
        {
            RoleName = rolename;
            ActionValue = actionValue;
        }

        public int RoleName { get; set; }
        public int ActionValue { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!CanAccessToAction(context.HttpContext))
                context.Result = new ForbidResult();
            if(!HasPermissonToAction(context.HttpContext))
                context.Result = new ForbidResult();
        }
        private bool CanAccessToAction(HttpContext httpContext)
        {
            var role = httpContext.User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(role, out int roleId) && roleId > RoleName)
                return true;
            return false;
        }
        private bool HasPermissonToAction(HttpContext httpContext)
        {
            var role = httpContext.User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(role, out int roleId))
            {
                var rolePermission = RoleFactory.GetPermissionArray(roleId); 
                if (rolePermission.Any() && rolePermission.Contains(ActionValue))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
