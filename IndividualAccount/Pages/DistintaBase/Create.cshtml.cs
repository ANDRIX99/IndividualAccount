using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.DistintaBase
{
    public class CreateModel : PageModel
    {
        private readonly IndividualAccount.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(IndividualAccount.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IndividualAccount.Model.DistintaBase DistintaBase { get; set; }

        [BindProperty]
        public IList<IndividualAccount.Model.VersioneDistintaBase> VersioneDistintaBase { get; set; }

        [BindProperty]
        public IList<IndividualAccount.Model.Item> Items { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("User Unauthenticated"); // DEBUG
                return Forbid();
            }

            Items = await _context.Items.ToListAsync();
            VersioneDistintaBase = await _context.VersioniDistintaBase.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Forbid();

            DistintaBase.CreatedById = user.Id;
            DistintaBase.CreatedAt = DateTime.UtcNow;
            DistintaBase.CreatedBy = user;
            DistintaBase.ModifiedById = null;
            DistintaBase.ModifiedAt = null;
            DistintaBase.DeletedById = null;
            DistintaBase.DeletedAt = null;

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"Campo: {key}, Errore: {error.ErrorMessage}");
                    }
                }
            }

            _context.DistinteBase.Add(DistintaBase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
