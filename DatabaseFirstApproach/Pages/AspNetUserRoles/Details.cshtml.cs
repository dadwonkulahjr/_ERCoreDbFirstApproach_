using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserRoles
{
    public class DetailsModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public DetailsModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public Models.AspNetUserRoles AspNetUserRoles { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AspNetUserRoles = await _context.AspNetUserRoles
                .Include(a => a.Role)
                .Include(a => a.User).FirstOrDefaultAsync(m => m.UserId == id);

            if (AspNetUserRoles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
