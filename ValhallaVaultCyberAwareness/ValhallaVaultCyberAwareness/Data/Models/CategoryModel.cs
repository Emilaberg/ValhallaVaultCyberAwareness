using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }



    }
}
