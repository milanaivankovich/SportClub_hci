namespace SportClub.Models
{
    public class UserSettings
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Theme { get; set; } = "Default"; 
        public string FontFamily { get; set; } = "Segoe UI";
        public double FontSize { get; set; } = 14;
    }
}