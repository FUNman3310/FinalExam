using FinalExam.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalExam.Areas.Manage.Services
{
    public class AdminLayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminLayoutService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
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
