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

            return categories;

        }
        public async Task<CategoryModel?> GetCategoryById(int id)
        {
            var singleCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            return singleCategory;

        }
        public async Task<CategoryModel?> AddCategory(CategoryModel newCategory)
        {

            _context.Add(newCategory);
            await _context.SaveChangesAsync();

            return newCategory;

        }

        public async Task<CategoryModel?> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            _context.Categories.Remove(categoryToDelete);

            await _context.SaveChangesAsync();
            return categoryToDelete;

        }
        public async Task<CategoryModel?> UpdateCategory(CategoryModel updatedCategory)
        {
            var categoryToUpdate = await _context.Categories.FirstOrDefaultAsync(c => c.Id == updatedCategory.Id);


            categoryToUpdate.CategoryName = updatedCategory.CategoryName;

            await _context.SaveChangesAsync();
            return updatedCategory;

        }

        //Get all categorys whith segments and subcategories
        public async Task<List<CategoryModel>?> GetAllCategoriesWithSegmentsAndSubCategories()
        {
            return await _context.Categories
                .Include(category => category.Segments)
                .ThenInclude(segment => segment.SubCategory)
                .ThenInclude(subCategory => subCategory.Questions)
                .ToListAsync();
        }

    }
}

