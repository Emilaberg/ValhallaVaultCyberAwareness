using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class PromptModel
    {
        [Key]
        public int Id { get; set; }
        //själva svarsalternativet
        [Required(ErrorMessage = "Prompt is required")]
        public string Prompt { get; set; } = null!;
        //om denna prompten är det korrekta svaret.
        public bool IsCorrect { get; set; } = false;

        //relationen till frågan
        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; } = null!;

    }
}
