using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{

    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryModel>?> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories != null)
            {

                return categories;
            }
            return null;

        }
        public async Task<CategoryModel?> GetCategoryById(int id)
        {
            var singleCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (singleCategory != null)
            {
                return singleCategory;
            }

            return null;

        }
        public async Task<CategoryModel?> AddCategory(CategoryModel newCategory)
        {
            if (newCategory != null)
            {
                _context.Add(newCategory);
                await _context.SaveChangesAsync();

                return newCategory;
            }
            return null;

        }

        public async Task<CategoryModel?> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryToDelete != null)
            {
                _context.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
                return categoryToDelete;
            }

            return null;

        }
        public async Task<CategoryModel?> UpdateCategory(CategoryModel updatedCategory)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updatedCategory.Id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = updatedCategory.CategoryName;

                await _context.SaveChangesAsync();
                return updatedCategory;

            }
            return null;

        }
        public async Task<List<CategoryModel>?> GetAllCategoriesWithSegmentsAndSubCategories()
        {
            var getAll = await _context.Categories
                .Include(category => category.Segments)
                .ThenInclude(segment => segment.SubCategory)
                .ThenInclude(subCategory => subCategory.Questions)
                .ThenInclude(question => question.Prompts)
                .ToListAsync();

            if (getAll != null)
            {
                return getAll;
            }
            return null;
        }
    }
}

