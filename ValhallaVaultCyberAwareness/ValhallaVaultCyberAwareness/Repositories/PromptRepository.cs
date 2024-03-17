using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;


namespace ValhallaVaultCyberAwareness.Repositories
{
    public class PromptRepository
    {
        private readonly ApplicationDbContext _context;
        public PromptRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<PromptModel>?> GetAllPrompts()
        {
            var prompts = await _context.Prompts.ToListAsync();
            if (prompts != null)
            {
                return prompts;

            }
            return null; ;

        }
        public async Task<PromptModel?> GetPromptById(int id)
        {
            var singleprompt = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == id);
            if (singleprompt != null)
            {
                return singleprompt;

            }
            return null;
        }
        public async Task<PromptModel?> AddPrompt(PromptModel newPrompt)
        {
            if (newPrompt != null)
            {
                _context.Add(newPrompt);
                await _context.SaveChangesAsync();

                return newPrompt;

            }
            return null;
        }

        public async Task<PromptModel?> DeletePrompt(int id)
        {
            var PromptToDelete = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == id);

            if (PromptToDelete != null)
            {
                _context.Prompts.Remove(PromptToDelete);

                await _context.SaveChangesAsync();
                return PromptToDelete;
            }

            return null;
        }
        public async Task<PromptModel?> UpdatePrompt(PromptModel updatedPrompt)
        {
            var PromptToUpdate = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == updatedPrompt.Id);
            if (PromptToUpdate != null)
            {
                PromptToUpdate.Prompt = updatedPrompt.Prompt;
                PromptToUpdate.IsCorrect = updatedPrompt.IsCorrect;

                await _context.SaveChangesAsync();

                return updatedPrompt;
            }
            return null;

        }

        //Get all prompts by questionId
        public async Task<List<PromptModel>?> GetPromptByQuestion(int questionId)
        {
            var questionPrompt = await _context.Prompts
               .Where(sc => sc.QuestionId == questionId)
               .ToListAsync();
            if (questionPrompt != null)
            {
                return questionPrompt;
            }
            return null;

        }

    }
}

