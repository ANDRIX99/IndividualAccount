using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IndividualAccount.Model;

namespace IndividualAccount.Pages.Item
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
        public IndividualAccount.Model.Item Item { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        { 
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                Console.WriteLine("User Unauthenticated"); // DEBUG
                return Forbid();
            }

            Console.WriteLine($"Saving Item: {Item.Name} created by {user.Id}"); // DEBUG
            Console.WriteLine($"User: {user.Id}"); // DEBUG

            Item.CreatedById = user.Id;
            Item.CreatedAt = DateTime.UtcNow;
            Item.CreatedBy = user;

            Console.WriteLine($"Item: {Item.Name} created by {Item.CreatedById}"); // DEBUG

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Invalid model state"); // DEBUG
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"Campo: {key}, Errore: {error.ErrorMessage}");
                    }
                }
                // return Page();
            }

            Item.ModifiedById = null;
            Item.ModifiedAt = null;
            Item.DeletedById = null;
            Item.DeletedAt = null;

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            Console.WriteLine("Saved completed"); // DEBUG

            return RedirectToPage("./Index");
        }
    }
}
