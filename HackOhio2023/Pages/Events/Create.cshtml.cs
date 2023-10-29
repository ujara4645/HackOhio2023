using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HackOhio2023.Data;
using HackOhio2023.Models;
using Microsoft.AspNetCore.Identity;

namespace HackOhio2023.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly HackOhio2023.Data.ApplicationDbContext _context;

        public CreateModel(HackOhio2023.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Events == null || Event == null)
            {
                return Page();
            }

            Event.AuthorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
