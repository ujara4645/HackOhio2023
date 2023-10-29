using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HackOhio2023.Models;

public enum Category
{
    Carpool,
    [Display(Name = "Charity Drive")]
    CharityDrive,
    [Display(Name = "Cultural/Religious Gathering")]
    CulturalReligiousGathering,
    Enhancement,
    Gaming,
    Pet,
    Picnic
}

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? AuthorId { get; set; }

    [Required]
    public Category Category { get; set; }

    public string? Description { get; set; }

    public string? DescriptionVideo { get; set; }

    public string? DescriptionImage { get; set; }

    public string? Location { get; set; }

    [DisplayName("Start date")]
    [DisplayFormat(DataFormatString = "{0:M/d/yy H:mm tt}")]
    public DateTime Start { get; set; }

    [DisplayName("End date")]
    [DisplayFormat(DataFormatString = "{0:M/d/yy H:mm tt}")]
    public DateTime End { get; set; }

    public bool Recurring { get; set; }

    [DisplayName("Recurring frequency")]
    public string? RecurringFrequency { get; set; }

    public string? Audience { get; set; }

    public List<ApplicationUserEvent> ApplicationUserEvents { get; } = new();

    public List<ApplicationUser> Participants { get; } = new();
}
