using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class QuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<QuestionModel>> GetAllQuestions()
        {
            var Questions = await _context.Questions.ToListAsync();

            return Questions;

        }
        public async Task<QuestionModel> GetQuestionById(int id)
        {
            var singleQuestion = await _context.Questions.FirstOrDefaultAsync(c => c.Id == id);


            return singleQuestion;

        }
        public async Task<QuestionModel> AddQuestion(QuestionModel newQuestion)
        {

            _context.Add(newQuestion);
            await _context.SaveChangesAsync();

            return newQuestion;

        }

        public async Task<QuestionModel> DeleteQuestion(int id)
        {
            var QuestionToDelete = await _context.Questions.FirstOrDefaultAsync(c => c.Id == id);


            _context.Questions.Remove(QuestionToDelete);

            await _context.SaveChangesAsync();
            return QuestionToDelete;

        }
        public async Task<QuestionModel> UpdateQuestion(QuestionModel updatedQuestion)
        {
            var QuestionToUpdate = await _context.Questions.FirstOrDefaultAsync(c => c.Id == updatedQuestion.Id);


            QuestionToUpdate.Question = updatedQuestion.Question;
            QuestionToUpdate.Explaination = updatedQuestion.Explaination;

            await _context.SaveChangesAsync();
            return updatedQuestion;

        }
        //hämtar alla questions med subCategoryId 
        public async Task<List<QuestionModel>> GetQuestionBySubCategory(int subCategoryId)
        {
            return await _context.Questions
               .Where(sc => sc.SubCategoryId == subCategoryId)
               .Include(q => q.Prompts)
               .ToListAsync();
        }

    }
}
