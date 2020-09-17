using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetRoleClaims
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public DetailsModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public Models.AspNetRoleClaims AspNetRoleClaims { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetRoleClaims = await _context.AspNetRoleClaims
                .Include(a => a.Role).FirstOrDefaultAsync(m => m.Id == id);

            if (AspNetRoleClaims == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
