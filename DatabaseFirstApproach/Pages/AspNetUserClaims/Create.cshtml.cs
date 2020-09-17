using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserClaims
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
        ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.AspNetUserClaims AspNetUserClaims { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AspNetUserClaims.Add(AspNetUserClaims);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
