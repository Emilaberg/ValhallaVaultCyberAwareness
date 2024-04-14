using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        //Exempelvis: Att skydda sig mot bedrägerier

        //[Required(ErrorMessage = "Category name is required")]
        //[MinLength(8, ErrorMessage = "Category name must be at least 8 characters long")]
        public string? CategoryName { get; set; }
        public List<SegmentModel> Segments { get; set; } = [];

    }
}
