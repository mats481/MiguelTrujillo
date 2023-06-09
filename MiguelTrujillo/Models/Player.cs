namespace MiguelTrujillo.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string? Name { get; set; }
        public required string? Country { get; set; }
        public List<RegisterSnatch> SnatchRecord { get; set; } = null!;
        public List<RegisterCleanAndJerk> CleanAndJerkRecord { get; set; } = null!;
        
    }
}
