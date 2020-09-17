using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly tuseTheProgrammer_TestDbContext _context;

        public CreateModel(tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TblDepartment TblDepartment { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TblDepartment.Add(TblDepartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
