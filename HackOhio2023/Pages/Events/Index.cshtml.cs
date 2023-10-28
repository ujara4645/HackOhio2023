using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HackOhio2023.Data;
using HackOhio2023.Models;

namespace HackOhio2023.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly HackOhio2023.Data.ApplicationDbContext _context;

        public IndexModel(HackOhio2023.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Events != null)
            {
                Event = await _context.Events.ToListAsync();
            }
        }
    }
}
