namespace MiguelTrujillo.Models
{
    public class RegisterCleanAndJerk
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int Weight { get; set; }
    }
}
