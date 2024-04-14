using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        //Exempelvis: Kreditkortsbedrägeri
        //[Required(ErrorMessage = "Subcategory name is required")]
        public string? SubCategoryName { get; set; }

        public bool IsCompleted { get; set; }

        public int SegmentId { get; set; }
        public SegmentModel Segment { get; set; } = null!;

        public List<QuestionModel> Questions { get; set; } = [];

    }
}
