using IndividualAccount.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IndividualAccount.Pages.Item
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
        public IndividualAccount.Model.Item Item { get; set; }

        public bool IsAdmin { get; set; } 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null) IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            Item = await _context.Items.FindAsync(id);
            if (Item == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // if (!ModelState.IsValid) return Page();

            var existingItem = await _context.Items.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            // Keep CreatedById and CreatedAt from database
            Item.CreatedById = existingItem.CreatedById;
            Item.CreatedAt = existingItem.CreatedAt;

            // Update only the editable field
            existingItem.Name = Item.Name;
            existingItem.Description = Item.Description;
            existingItem.IsDeleted = Item.IsDeleted;

            // Trace user edit
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
