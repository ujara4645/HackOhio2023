using System.ComponentModel.DataAnnotations;

namespace HackOhio2023.Models;

public class Event
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int AuthorId { get; set; }

    public int Category { get; set; }

    public string? Description { get; set; }

    public string? DescriptionVideo { get; set; }

    public string? DescriptionImage { get; set; }

    public string? Location { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public bool Recurring { get; set; }

    public string? RecurringFrequency { get; set; }

    public string? Audience { get; set; }

    //public List<ApplicationUserEvent> ApplicationUserEvents { get; } = new();

    public List<ApplicationUser> Participants { get; } = new();
}
