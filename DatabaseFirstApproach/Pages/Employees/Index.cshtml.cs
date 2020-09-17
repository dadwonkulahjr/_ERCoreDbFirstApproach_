using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public IndexModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public IList<TblEmployees> TblEmployees { get;set; }

        public async Task OnGetAsync()
        {
            TblEmployees = await _context.TblEmployees
                .Include(t => t.Department)
                .Include(t => t.Gender).ToListAsync();
        }
    }
}
