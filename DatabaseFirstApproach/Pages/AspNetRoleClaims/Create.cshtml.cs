using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetRoleClaims
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public CreateModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoleId"] = new SelectList(_context.AspNetRoles, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.AspNetRoleClaims AspNetRoleClaims { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AspNetRoleClaims.Add(AspNetRoleClaims);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
