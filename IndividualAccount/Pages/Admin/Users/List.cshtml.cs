using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualAccount.Data;

namespace IndividualAccount.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")] // only admin can see Users list
    public class ListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ListModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<UserWithRoles> Users { get; set; } // list with user and role

        public class UserWithRoles
        {
            public IdentityUser User { get; set; }
            public List<string> Roles { get; set; }
        }

        public async Task OnGetAsync()
        {
            var users = _userManager.Users.ToList();
            Users = new List<UserWithRoles>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                Users.Add(new UserWithRoles
                {
                    User = user,
                    Roles = roles.ToList()
                });
            }
        }
    }
}
