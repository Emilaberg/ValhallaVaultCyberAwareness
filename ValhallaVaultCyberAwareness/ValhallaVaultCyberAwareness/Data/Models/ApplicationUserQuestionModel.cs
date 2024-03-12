namespace ValhallaVaultCyberAwareness.Data.Models
{
    public class ApplicationUserQuestionModel
    {
        public string ApplicationUserId { get; set; } = null!;
        public int QuestionModelId { get; set; }
        public bool IsCorrectlyAnswered { get; set; }
    }
}
