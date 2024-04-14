using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class SegmentModel
    {
        [Key]
        public int Id { get; set; }
        // Namnet för själva segmentet, som "Att skydda sig mot bedrägerier del 1 "
        //[Required(ErrorMessage = "Segment name is required")]
        //[MinLength(4, ErrorMessage = "Segment name must be at least 4 characters long")]
        public string? SegmentName { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; } = null!;

        public List<SubCategoryModel> SubCategory { get; set; } = [];

    }
}
