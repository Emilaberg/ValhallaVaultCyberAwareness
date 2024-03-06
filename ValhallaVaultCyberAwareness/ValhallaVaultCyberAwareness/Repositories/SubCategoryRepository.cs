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
            var SubCategories = await _context.SubCategories.ToListAsync();

            return SubCategories;

        }
        public async Task<SubCategoryModel> GetSubCategoryById(int id)
        {
            var singleSubCategory = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            if (singleSubCategory != null)
            {
                return singleSubCategory;
            }
            throw new NullReferenceException();
        }
        public async Task<SubCategoryModel> AddSubCategory(SubCategoryModel newSubCategory)
        {
            if (newSubCategory != null)
            {
                _context.Add(newSubCategory);
                await _context.SaveChangesAsync();

                return newSubCategory;
            }
            throw new NullReferenceException();
        }

        public async Task<SubCategoryModel> DeleteSubCategory(int id)
        {
            var SubCategoryToDelete = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);

            if (SubCategoryToDelete != null)
            {
                _context.SubCategories.Remove(SubCategoryToDelete);

                await _context.SaveChangesAsync();
                return SubCategoryToDelete;
            }
            throw new NullReferenceException();
        }
        public async Task<SubCategoryModel> UpdateSubCategory(SubCategoryModel updatedSubCategory)
        {
            var SubCategoryToUpdate = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == updatedSubCategory.Id);

            if (SubCategoryToUpdate != null)
            {
                SubCategoryToUpdate.SubCategoryName = updatedSubCategory.SubCategoryName;

                await _context.SaveChangesAsync();
                return updatedSubCategory;
            }
            throw new NullReferenceException();
        }


    }
}
