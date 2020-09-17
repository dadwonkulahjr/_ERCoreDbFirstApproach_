using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserLogin
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public DeleteModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AspNetUserLogins AspNetUserLogins { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserLogins = await _context.AspNetUserLogins
                .Include(a => a.User).FirstOrDefaultAsync(m => m.LoginProvider == id);

            if (AspNetUserLogins == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserLogins = await _context.AspNetUserLogins.FindAsync(id);

            if (AspNetUserLogins != null)
            {
                _context.AspNetUserLogins.Remove(AspNetUserLogins);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
