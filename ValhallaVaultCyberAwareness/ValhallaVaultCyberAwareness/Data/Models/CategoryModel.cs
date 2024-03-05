using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        //Exempelvis: Att skydda sig mot bedrägerier
        public string? CategoryName { get; set; }
        public List<SegmentModel> Segments { get; set; } = [];

    }
}
