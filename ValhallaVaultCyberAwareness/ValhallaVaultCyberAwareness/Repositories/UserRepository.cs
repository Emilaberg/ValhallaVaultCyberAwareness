using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context, SignInManager<ApplicationUser> signiInManager)
        {
            _context = context;

        }

        public async Task<List<QuestionModel>> GetUserQuestions(string userId)
        {
            return await _context.Questions
             .Where(q => q.UsersAnsweredQuestions.Any(uq => uq.ApplicationUserId == userId)).ToListAsync();

        }
    }
}
