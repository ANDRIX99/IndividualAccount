using IndividualAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.DistintaBase
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<IndividualAccount.Model.DistintaBase> DistinteBase { get; set; }

        public IList<IndividualAccount.Model.Item> Items { get; set; }

        public IList<IndividualAccount.Model.VersioneDistintaBase> VersioniDistintaBase { get; set; }

        public bool IsAdmin { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            DistinteBase = await _context.DistinteBase
                .Include(c => c.CreatedBy)
                .Include(c => c.ModifiedBy)
                .Include(c => c.DeletedBy)
                .ToListAsync();

            Items = await _context.Items.ToListAsync();
            VersioniDistintaBase = await _context.VersioniDistintaBase.ToListAsync();
        }
    }
}
