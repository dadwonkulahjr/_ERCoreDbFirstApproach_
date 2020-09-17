using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserTokens
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public DeleteModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AspNetUserTokens AspNetUserTokens { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserTokens = await _context.AspNetUserTokens
                .Include(a => a.User).FirstOrDefaultAsync(m => m.UserId == id);

            if (AspNetUserTokens == null)
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

            AspNetUserTokens = await _context.AspNetUserTokens.FindAsync(id);

            if (AspNetUserTokens != null)
            {
                _context.AspNetUserTokens.Remove(AspNetUserTokens);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
