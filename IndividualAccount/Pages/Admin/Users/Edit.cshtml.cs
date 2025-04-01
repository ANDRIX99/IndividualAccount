using IndividualAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualAccount.Pages.Admin.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public List<UserRoleViewModel> Users { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Users = _userManager.Users.Select(u => new UserRoleViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();

            foreach (var user in Users)
            {
                var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
                user.Role = roles.FirstOrDefault();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, newRole);

            return RedirectToPage();
        }
    }

    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
