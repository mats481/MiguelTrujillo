namespace MiguelTrujillo.Models
{
    internal class PlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int? SnatchRegister { get; set; }
        public int? CleanAndJerkRecord { get; set; }
    }
}