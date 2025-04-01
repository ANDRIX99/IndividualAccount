using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.VersioneDistintaBase
{
    public class IndexModel : PageModel
    {
        private readonly IndividualAccount.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(IndividualAccount.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public IList<IndividualAccount.Model.VersioneDistintaBase> VersioneDistintaBase { get; set; }

        [BindProperty]
        public IList<IndividualAccount.Model.Item> Items { get; set; }

        public bool IsAdmin { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            VersioneDistintaBase = await _context.VersioniDistintaBase
                .Include(c => c.CreatedBy)
                .Include(c => c.ModifiedBy)
                .Include(c => c.DeletedBy)
                .ToListAsync();
            Items = await _context.Items.ToListAsync();
        }
    }
}
