using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstApproach.Models;

namespace DatabaseFirstApproach.Pages.AspNetUserLogin
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext _context;

        public IndexModel(DatabaseFirstApproach.Models.tuseTheProgrammer_TestDbContext context)
        {
            _context = context;
        }

        public IList<AspNetUserLogins> AspNetUserLogins { get;set; }

        public async Task OnGetAsync()
        {
            AspNetUserLogins = await _context.AspNetUserLogins
                .Include(a => a.User).ToListAsync();
        }
    }
}
