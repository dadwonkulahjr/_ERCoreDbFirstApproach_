using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserRoles
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
        ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Models.AspNetUserRoles AspNetUserRoles { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AspNetUserRoles.Add(AspNetUserRoles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
