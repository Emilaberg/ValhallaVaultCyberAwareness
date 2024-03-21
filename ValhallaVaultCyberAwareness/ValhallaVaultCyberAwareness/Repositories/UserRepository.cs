using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<QuestionModel>> GetUserQuestions(string userId)
        {
            return await _context.Questions
             .Where(q => q.UsersAnsweredQuestions.Any(uq => uq.ApplicationUserId == userId)).ToListAsync();

        }

        public async Task SaveUserAnswer(ApplicationUserQuestionModel userAnswer)
        {
            var existingUserAnswer = await _context.ApplicationUserQuestions
                .Where(uq => uq.ApplicationUserId == userAnswer.ApplicationUserId && uq.QuestionModelId == userAnswer.QuestionModelId)
                .FirstOrDefaultAsync();

            if (existingUserAnswer != null)
            {
                // Update the existing answer
                existingUserAnswer.IsCorrectlyAnswered = userAnswer.IsCorrectlyAnswered;
            }
            else
            {
                // Add a new answer
                _context.ApplicationUserQuestions.Add(userAnswer);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ApplicationUserQuestionModel?> GetUserAnswers(string userId, int questionId)
        {
            return await _context.ApplicationUserQuestions
             .Where(uq => uq.ApplicationUserId == userId && uq.QuestionModelId == questionId).FirstOrDefaultAsync();
        }
    }
}
