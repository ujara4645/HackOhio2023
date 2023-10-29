using HackOhio2023.Data;
using HackOhio2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HackOhio2023.Pages.Events;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Event> Event { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Categories { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    public async Task OnGetAsync()
    {
        if (_context.Events != null)
        {
            var events = await _context.Events.ToListAsync();

            if (!string.IsNullOrEmpty(Categories))
            {
                events = events.Where(e => Categories.Split(',').Select(int.Parse).Contains((int)e.Category)).ToList();
            }

            if (!string.IsNullOrEmpty(Search))
            {
                events = events.Where(e => e.Name!.Contains(Search, StringComparison.OrdinalIgnoreCase) || e.Description.Contains(Search)).ToList();
            }

            Event = events;
        }
    }
}
