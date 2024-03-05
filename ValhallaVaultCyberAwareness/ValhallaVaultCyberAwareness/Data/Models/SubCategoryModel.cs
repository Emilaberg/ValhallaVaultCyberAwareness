using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string? SubCategoryName { get; set; }

    }
}
