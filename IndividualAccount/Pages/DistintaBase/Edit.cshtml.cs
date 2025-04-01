using IndividualAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.DistintaBase
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IndividualAccount.Model.DistintaBase DistintaBase { get; set; }
        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            DistintaBase = await _context.DistinteBase.FindAsync(id);
            if (DistintaBase == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var existingItem = await _context.DistinteBase.FindAsync(id);
            if (existingItem == null) return NotFound();

            DistintaBase.CreatedById = existingItem.CreatedById;
            DistintaBase.CreatedAt = existingItem.CreatedAt;

            existingItem.Quantita = DistintaBase.Quantita;
            existingItem.IsDeleted = DistintaBase.IsDeleted;

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                existingItem.ModifiedById = user.Id;
                existingItem.ModifiedAt = DateTime.UtcNow;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("Index");
        }
    }
}
