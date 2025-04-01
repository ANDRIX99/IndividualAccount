using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.VersioneDistintaBase
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
        public IndividualAccount.Model.VersioneDistintaBase VersioneDistintaBase { get; set; }

        [BindProperty]
        public IList<IndividualAccount.Model.Item> Items { get; set; }

        public async Task OnGetAsync()
        {
            Items = await _context.Items.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                Console.WriteLine("User Unauthenticated"); // DEBUG
                return Forbid();
            }

            VersioneDistintaBase.CreatedById = user.Id;
            VersioneDistintaBase.CreatedAt = DateTime.UtcNow;
            VersioneDistintaBase.CreatedBy = user;

            VersioneDistintaBase.ModifiedById = null;
            VersioneDistintaBase.ModifiedAt = null;
            VersioneDistintaBase.DeletedById = null;
            VersioneDistintaBase.DeletedAt = null;

            _context.VersioniDistintaBase.Add(VersioneDistintaBase);
            await _context.SaveChangesAsync();

            Console.WriteLine("Saved completed"); // DEBUG

            return RedirectToPage("./Index");
        }
    }
}
