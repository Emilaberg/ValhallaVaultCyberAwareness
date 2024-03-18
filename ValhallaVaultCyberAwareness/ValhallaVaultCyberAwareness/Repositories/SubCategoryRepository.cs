using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SubCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategoryModel>> GetAllSubCategories()
        {
            return await _context.SubCategories.ToListAsync();


        }
        public async Task<SubCategoryModel> GetSubCategoryById(int id)
        {
            var singleSubCategory = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            return singleSubCategory;
        }
        public async Task<SubCategoryModel> AddSubCategory(SubCategoryModel newSubCategory)
        {

            _context.Add(newSubCategory);
            await _context.SaveChangesAsync();

            return newSubCategory;

        }

        public async Task<SubCategoryModel> DeleteSubCategory(int id)
        {
            var SubCategoryToDelete = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            _context.SubCategories.Remove(SubCategoryToDelete);

            await _context.SaveChangesAsync();
            return SubCategoryToDelete;


        }
        public async Task<SubCategoryModel> UpdateSubCategory(SubCategoryModel updatedSubCategory)
        {
            var SubCategoryToUpdate = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == updatedSubCategory.Id);


            SubCategoryToUpdate.SubCategoryName = updatedSubCategory.SubCategoryName;
            SubCategoryToUpdate.IsCompleted = updatedSubCategory.IsCompleted;

            await _context.SaveChangesAsync();
            return updatedSubCategory;

        }

        //hämtar alla subkategorier med SegmentId 
        public async Task<List<SubCategoryModel>> GetSubcategoriesBySegment(int segmentId)
        {
            return await _context.SubCategories
                .Where(sc => sc.SegmentId == segmentId)
                .ToListAsync();
        }

        // update IsCompleted

        public async Task UpdateSubCategoryCompletion(int subCategoryId, bool isCompleted)
        {
            var subCategory = await _context.SubCategories.FindAsync(subCategoryId);
            if (subCategory != null)
            {
                subCategory.IsCompleted = isCompleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<double> GetCompletionPercentage(int segmentId)
        {
            var subCategories = await GetSubcategoriesBySegment(segmentId);
            if (subCategories == null || subCategories.Count == 0)
            {
                return 0;
            }

            int completedCount = subCategories.Count(sc => sc.IsCompleted);
            return (double)completedCount / subCategories.Count * 100;
        }

        public async Task<bool> CanAccessNextSubCategory(string userId, int currentSubCategoryId)
        {
            var questions = await _context.Questions
                .Where(q => q.SubCategoryId == currentSubCategoryId)
                .ToListAsync();

            if (!questions.Any())
            {
                // If there are no questions in the current subcategory, allow access to the next one
                return true;
            }

            var correctAnswersCount = await _context.ApplicationUserQuestions
                .Where(uq => uq.ApplicationUserId == userId && uq.IsCorrectlyAnswered)
                .CountAsync();

            var totalQuestionsCount = questions.Count;

            return ((double)correctAnswersCount / totalQuestionsCount) >= 0.8;
        }



    }
}
