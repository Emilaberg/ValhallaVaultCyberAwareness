using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<QuestionModel> AnsweredQuestions { get; } = [];
    }

}
