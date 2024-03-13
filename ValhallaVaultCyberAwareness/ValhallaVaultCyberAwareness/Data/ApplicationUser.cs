using Microsoft.AspNetCore.Identity;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public List<QuestionModel> AnsweredQuestions { get; } = [];
        public List<ApplicationUserQuestionModel> UsersAnsweredQuestions { get; set; } = [];

    }

}
