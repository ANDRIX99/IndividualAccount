using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndividualAccount.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")] // only admin can reset password
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ResetPasswordModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string UserId { get; set; }

        public async Task OnGetAsync(string id)
        {
            UserId = id;
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError("", "Le password non corrispondono.");
                return Page();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Impossibile trovare l'utente con ID '{id}'.");
            }

            // Imposta la nuova password
            var result = await _userManager.RemovePasswordAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }

            result = await _userManager.AddPasswordAsync(user, Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }

            // Dopo aver reimpostato la password, reindirizza l'admin alla lista degli utenti
            return RedirectToPage("/Admin/Users/List");
        }
    }
}
