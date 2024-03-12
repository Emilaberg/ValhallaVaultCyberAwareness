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
        public async Task<List<PromptModel>> GetAllPrompts()
        {
            var prompts = await _context.Prompts.ToListAsync();

            return prompts;

        }
        public async Task<PromptModel> GetPromptById(int id)
        {
            var singleprompt = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == id);


            return singleprompt;

        }



        public async Task<PromptModel> AddPrompt(PromptModel newPrompt)
        {

            _context.Add(newPrompt);
            await _context.SaveChangesAsync();

            return newPrompt;

        }

        public async Task<PromptModel> DeletePrompt(int id)
        {
            var PromptToDelete = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == id);


            _context.Prompts.Remove(PromptToDelete);

            await _context.SaveChangesAsync();
            return PromptToDelete;

        }
        public async Task<PromptModel> UpdatePrompt(PromptModel updatedPrompt)
        {
            var PromptToUpdate = await _context.Prompts.FirstOrDefaultAsync(c => c.Id == updatedPrompt.Id);


            PromptToUpdate.Prompt = updatedPrompt.Prompt;
            PromptToUpdate.IsCorrect = updatedPrompt.IsCorrect;

            await _context.SaveChangesAsync();
            return updatedPrompt;

        }

        //hämtar alla prompts med questionId 
        public async Task<List<PromptModel>> GetPromptByQuestion(int questionId)
        {
            var prompts = await _context.Prompts
               .Where(sc => sc.QuestionId == questionId)
               .ToListAsync();

            return prompts;

        }

    }
}

