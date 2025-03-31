using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.Item
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
        public IndividualAccount.Model.Item Item { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Item = await _context.Items
                .Include(i => i.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                item.DeletedById = user.Id;
                item.DeletedAt = DateTime.UtcNow;
                item.IsDeleted = true; // Marca l'item come eliminato
            }

            _context.Attach(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
