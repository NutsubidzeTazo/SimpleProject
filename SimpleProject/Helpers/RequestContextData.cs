using System.Security.Claims;

namespace SimpleProject.Helpers
{
    public class RequestContextData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestContextData(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
        public string? Username => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "username").Value;
        public decimal? Balance => decimal.Parse(_httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type == "balance").Value);

    }
}
