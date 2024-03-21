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
        public async Task<List<SubCategoryModel>?> GetAllSubCategories()
        {
            var SubCategories = await _context.SubCategories.ToListAsync();
            if (SubCategories != null)
            {
                return SubCategories;

            }
            return null;

        }
        public async Task<SubCategoryModel?> GetSubCategoryById(int id)
        {
            var singleSubCategory = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            if (singleSubCategory != null)
            {
                return singleSubCategory;

            }
            return null;
        }
        public async Task<SubCategoryModel?> AddSubCategory(SubCategoryModel newSubCategory)
        {
            if (newSubCategory != null)
            {
                _context.Add(newSubCategory);
                await _context.SaveChangesAsync();

                return newSubCategory;

            }
            return null;
        }

        public async Task<SubCategoryModel?> DeleteSubCategory(int id)
        {
            var subCategoryToDelete = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            if (subCategoryToDelete != null)
            {
                _context.SubCategories.Remove(subCategoryToDelete);

                await _context.SaveChangesAsync();
                return subCategoryToDelete;

            }
            return null;
        }
        public async Task<SubCategoryModel?> UpdateSubCategory(SubCategoryModel updatedSubCategory)
        {
            var subCategoryToUpdate = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == updatedSubCategory.Id);

            if (subCategoryToUpdate != null)
            {
                subCategoryToUpdate.SubCategoryName = updatedSubCategory.SubCategoryName;
                subCategoryToUpdate.IsCompleted = updatedSubCategory.IsCompleted;

                await _context.SaveChangesAsync();
                return updatedSubCategory;

            }
            return null;
        }

        //hämtar alla subkategorier med SegmentId 
        public async Task<List<SubCategoryModel>?> GetSubcategoriesBySegment(int segmentId)
        {
            var segmentSubCategory = await _context.SubCategories
                .Where(sc => sc.SegmentId == segmentId)
                .ToListAsync();
            if (segmentSubCategory != null)
            {
                return segmentSubCategory;

            }
            return null;
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
