using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HackOhio2023.Data;
using HackOhio2023.Models;
using Microsoft.AspNetCore.Identity;

namespace HackOhio2023.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly HackOhio2023.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(HackOhio2023.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Event Event { get; set; } = default!;

        public string? OrganizerName { get; set; }

        public bool IsOrganizer { get; set; }

        public bool HasJoined { get; set; }

        public IList<ApplicationUser> Attendees { get; set; }

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
                var organizer = await _userManager.FindByIdAsync(@event.AuthorId);
                OrganizerName = organizer.UserName;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                HasJoined = await _context.ApplicationUserEvents!.AnyAsync(ue =>
                    ue.ApplicationUserId == userId && ue.EventId == @event.Id);
                IsOrganizer = userId == organizer.Id;
                //Attendees = Event.Participants;
                Attendees = await _context.ApplicationUserEvents.Where(ue => ue.EventId == Event.Id)
                    .Join(_context.ApplicationUser, ue => ue.ApplicationUserId,
                    u => u.Id, (_, u) => u)
                    .ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string? hasJoined)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);

            if (@event != null)
            {
                Event = @event;
            }

            HasJoined = hasJoined == bool.TrueString;
            if (HasJoined)
            {
                var applicationUserEvent =
                    await _context.ApplicationUserEvents.FindAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                        Event.Id);
                _context.ApplicationUserEvents.Remove(applicationUserEvent);
            }
            else
            {
                var _ = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var applicationUserEvent = new ApplicationUserEvent
                {
                    ApplicationUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    EventId = Event.Id
                };
                _context.ApplicationUserEvents?.Add(applicationUserEvent);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.Id))
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

        private bool EventExists(int id)
        {
            return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
