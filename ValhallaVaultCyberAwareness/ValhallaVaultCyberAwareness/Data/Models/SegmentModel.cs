using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class SegmentModel
    {
        [Key]
        public int Id { get; set; }
        public string? SegmentName { get; set; }
    }
}
