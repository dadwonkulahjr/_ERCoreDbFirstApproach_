using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserClaims
{
    public class DeleteModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public DeleteModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.AspNetUserClaims AspNetUserClaims { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserClaims = await _context.AspNetUserClaims
                .Include(a => a.User).FirstOrDefaultAsync(m => m.Id == id);

            if (AspNetUserClaims == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserClaims = await _context.AspNetUserClaims.FindAsync(id);

            if (AspNetUserClaims != null)
            {
                _context.AspNetUserClaims.Remove(AspNetUserClaims);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
