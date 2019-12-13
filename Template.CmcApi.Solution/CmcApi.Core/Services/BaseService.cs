using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace CmcApi.Core.Services
{
    public class BaseService: IBaseService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseService(
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId()
        {
            var claim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim?.Value;
            return userId;
        }
    }
}
