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
        public async Task<List<QuestionModel>?> GetAllQuestions()
        {
            var questions = await _context.Questions.ToListAsync();
            if (questions != null)
            {
                return questions;
            }
            return null;
        }
        public async Task<QuestionModel?> GetQuestionById(int id)
        {
            var singleQuestion = await _context.Questions.FirstOrDefaultAsync(c => c.Id == id);
            if (singleQuestion != null)
            {
                return singleQuestion;

            }
            return null;

        }
        public async Task<QuestionModel?> AddQuestion(QuestionModel newQuestion)
        {
            if (newQuestion != null)
            {
                _context.Add(newQuestion);
                await _context.SaveChangesAsync();

                return newQuestion;

            }
            return null;
        }

        public async Task<QuestionModel?> DeleteQuestion(int id)
        {
            var questionToDelete = await _context.Questions.FirstOrDefaultAsync(c => c.Id == id);
            if (questionToDelete != null)
            {
                _context.Questions.Remove(questionToDelete);

                await _context.SaveChangesAsync();
                return questionToDelete;

            }
            return null;

        }
        public async Task<QuestionModel?> UpdateQuestion(QuestionModel updatedQuestion)
        {
            var questionToUpdate = await _context.Questions.FirstOrDefaultAsync(c => c.Id == updatedQuestion.Id);

            if (questionToUpdate != null)
            {
                questionToUpdate.Question = updatedQuestion.Question;
                questionToUpdate.Explaination = updatedQuestion.Explaination;

                await _context.SaveChangesAsync();
                return updatedQuestion;
            }
            return null;

        }

        //Get question by Sub category
        public async Task<List<QuestionModel>?> GetQuestionBySubCategory(int subCategoryId)
        {
            var subcategoryQuestion = await _context.Questions
               .Where(sc => sc.SubCategoryId == subCategoryId)
               .ToListAsync();
            if (subcategoryQuestion != null)
            {
                return subcategoryQuestion;
            }
            return null;
        }

    }
}
