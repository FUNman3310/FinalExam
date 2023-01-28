using FinalExam.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalExam.Section
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<AppUser> GetUser()
        {
            AppUser User = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                User = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }

            if (User != null) return User;
            return null;

        }
    }
}
