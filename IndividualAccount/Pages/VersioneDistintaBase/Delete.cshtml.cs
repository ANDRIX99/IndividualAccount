using IndividualAccount.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.VersioneDistintaBase
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
        public IndividualAccount.Model.VersioneDistintaBase VersioneDistintaBase { get; set; }

        [BindProperty]
        public IndividualAccount.Model.Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            VersioneDistintaBase = await _context.VersioniDistintaBase
                .AsNoTracking()
                .Include(i => i.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);

            Item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            if (VersioneDistintaBase == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var versionedistintabase = await _context.VersioniDistintaBase.FindAsync(id);
            if (versionedistintabase == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                versionedistintabase.DeletedById = user.Id;
                versionedistintabase.DeletedAt = DateTime.UtcNow;
                versionedistintabase.IsDeleted = true;
            }

            _context.VersioniDistintaBase.Update(versionedistintabase);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
