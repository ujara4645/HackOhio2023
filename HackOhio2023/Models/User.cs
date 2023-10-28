class User 
{

    public User() 
    { 
        Events = new List<Event>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public List<Event> Events { get; } = new();
}