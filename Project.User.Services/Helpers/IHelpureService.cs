using System.Security.Claims;

namespace OnTime.Services.Helpers
{
    public interface IHelpureService
    {
        public Task<string> GetUserAsync(ClaimsPrincipal user);
    }
}
