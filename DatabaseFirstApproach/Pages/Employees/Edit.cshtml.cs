using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly tuseTheProgrammer_TestDbContext _context;

        public EditModel(tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblEmployees TblEmployees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblEmployees = await _context.TblEmployees
                .Include(t => t.Department)
                .Include(t => t.Gender).FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (TblEmployees == null)
            {
                return RedirectToPage("/ErrorHandler/PageNotFound");
            }
           ViewData["DepartmentId"] = new SelectList(_context.TblDepartment, "Id", "DepartmentName");
           ViewData["GenderId"] = new SelectList(_context.TblGender, "Id", "Sex");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblEmployees).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeesExists(TblEmployees.EmployeeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblEmployeesExists(int id)
        {
            return _context.TblEmployees.Any(e => e.EmployeeId == id);
        }
    }
}
