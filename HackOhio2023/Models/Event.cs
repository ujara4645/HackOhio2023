using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

class Event 
{

    public Event() 
    { 
        Participants = new List<User>();
    }

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
    public List<User> Participants { get; } = new();

}