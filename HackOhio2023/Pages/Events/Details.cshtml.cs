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
    public class DetailsModel : PageModel
    {
        private readonly HackOhio2023.Data.ApplicationDbContext _context;

        public DetailsModel(HackOhio2023.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Event Event { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }
            else 
            {
                Event = @event;
            }
            return Page();
        }
    }
}
