using demo_azure_deployment.Config;
using demo_azure_deployment.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace demo_azure_deployment.Pages.PersonPages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.People != null)
            {
                Person = await _context.People.ToListAsync();
            }
        }
    }
}
