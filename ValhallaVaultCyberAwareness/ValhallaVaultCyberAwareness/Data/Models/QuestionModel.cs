using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{

    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = null!;
    }
}
