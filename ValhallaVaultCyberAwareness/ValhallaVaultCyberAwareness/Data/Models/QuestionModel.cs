using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{

    public class QuestionModel
    {
        [Key]
        public int Id { get; set; }
        //själva frågan till 
        //[Required(ErrorMessage = "Question is required")]
        //[MinLength(5, ErrorMessage = "Question name must be at least 5 characters long")]
        public string Question { get; set; } = null!;

        //förklaring till korrekt fråga
        public string? Explaination { get; set; }

        //relationen till Subkategorin
        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategory { get; set; } = null!;

        //relationen till prompts
        public List<PromptModel> Prompts { get; set; } = [];

        //many to many relationship
        //public List<ApplicationUser> ApplicationUsers { get; } = [];
        public List<ApplicationUserQuestionModel> UsersAnsweredQuestions { get; set; } = [];
    }
}
