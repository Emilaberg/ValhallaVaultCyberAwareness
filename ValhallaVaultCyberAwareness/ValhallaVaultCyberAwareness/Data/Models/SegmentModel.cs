using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class SegmentModel
    {
        [Key]
        public int Id { get; set; }
        // Namnet för själva segmentet, som "Att skydda sig mot bedrägerier del 1 "
        public string? SegmentName { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; } = null!;

        public List<SubCategoryModel> SubCategory { get; set; } = [];

    }
}
