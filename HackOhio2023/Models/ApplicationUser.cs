using Microsoft.AspNetCore.Identity;

namespace HackOhio2023.Models;

public class ApplicationUser : IdentityUser
{
    public List<ApplicationUserEvent> ApplicationUserEvents { get; } = new();

    public List<Event> Events { get; } = new();
}
