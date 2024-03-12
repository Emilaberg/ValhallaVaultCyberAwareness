namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class IpLoggerModel
    {
        public int Id { get; set; }
        public string Ip { get; set; } = null!;
        public string? Location { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
