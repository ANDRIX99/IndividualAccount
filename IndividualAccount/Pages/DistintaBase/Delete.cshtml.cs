using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.DistintaBase
{
    public class DeleteModel : PageModel
    {
        private readonly IndividualAccount.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(IndividualAccount.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IndividualAccount.Model.DistintaBase DistintaBase { get; set; }

        [BindProperty]
        public IndividualAccount.Model.VersioneDistintaBase VersioneDistintaBase { get; set; }

        [BindProperty]
        public IndividualAccount.Model.Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            DistintaBase = await _context.DistinteBase
                .AsNoTracking()
                .Include(d => d.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (DistintaBase == null) return NotFound();

            VersioneDistintaBase = await _context.VersioniDistintaBase.FirstOrDefaultAsync(m => m.Id == DistintaBase.IdVersione);
            Item = await _context.Items.FirstOrDefaultAsync(m => m.Id == DistintaBase.IdFiglio);

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var distintaBase = await _context.DistinteBase.FindAsync(id);
            if (distintaBase == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                distintaBase.DeletedById = user.Id;
                distintaBase.DeletedAt = DateTime.UtcNow;
                distintaBase.IsDeleted = true;
            }

            _context.DistinteBase.Update(distintaBase);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
