using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndividualAccount.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Role { get; set; }

        public void OnGet()
        {
            // Logic to execute when the page is requested (no init in this case)
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Role))
            {
                ModelState.AddModelError("", "Tutti i campi sono obbligatori.");
                return Page();
            }

            // Verifica se il ruolo esiste
            if (!await _roleManager.RoleExistsAsync(Role))
            {
                ModelState.AddModelError("", "Il ruolo non esiste.");
                return Page();
            }

            // Crea l'utente
            var user = new IdentityUser { UserName = Email, Email = Email };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                // Aggiungi il ruolo all'utente
                await _userManager.AddToRoleAsync(user, Role);
                return RedirectToPage("List");  // O alla pagina che visualizza la lista degli utenti
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return Page();
        }
    }
}
