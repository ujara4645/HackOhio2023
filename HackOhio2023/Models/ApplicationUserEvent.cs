﻿namespace HackOhio2023.Models;

public class ApplicationUserEvent
{
    public string? ApplicationUserId { get; set; }
    public int EventId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = null!;
    public Event Event { get; set; } = null!;
}
