using IndividualAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.VersioneDistintaBase
{
    public class DetailModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DetailModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Model.VersioneDistintaBase VersioneDistintaBase { get; set; }

        [BindProperty]
        public IList<Model.DistintaBase> DistintaBase { get; set; }

        [BindProperty]
        public IList<Model.Item> Item { get; set; }

        public bool IsAdmin { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            VersioneDistintaBase = await _context.VersioniDistintaBase
                .Include(v => v.CreatedBy)
                .Include(v => v.ModifiedBy)
                .Include(v => v.DeletedBy)
                .FirstOrDefaultAsync(v => v.Id == id);

            DistintaBase = await _context.DistinteBase.ToListAsync();
            Item = await _context.Items.ToListAsync();

            if (VersioneDistintaBase is null || DistintaBase is null || Item is null) return NotFound();

            var user = await _userManager.GetUserAsync(User);
            if (user != null) IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            return Page();
        }
    }
}
