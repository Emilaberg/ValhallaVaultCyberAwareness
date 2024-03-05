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
        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var categories = await _context.Category.ToListAsync();

            return categories;

        }
        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var singleCategory = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (singleCategory != null)
            {
                return singleCategory;
            }
            throw new NullReferenceException();
        }
        public async Task<CategoryModel> AddCategory(CategoryModel newCategory)
        {
            if (newCategory != null)
            {
                _context.Add(newCategory);
                await _context.SaveChangesAsync();

                return newCategory;
            }
            throw new NullReferenceException();
        }

        public async Task<CategoryModel> DeleteCategory(int id)
        {
            var categoryToDelete = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryToDelete != null)
            {
                _context.Category.Remove(categoryToDelete);

                await _context.SaveChangesAsync();
                return categoryToDelete;
            }
            throw new NullReferenceException();
        }
        public async Task<CategoryModel> UpdateCategory(CategoryModel updatedCategory)
        {
            var categoryToUpdate = await _context.Category.FirstOrDefaultAsync(c => c.Id == updatedCategory.Id);

            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryName = updatedCategory.CategoryName;

                await _context.SaveChangesAsync();
                return updatedCategory;
            }
            throw new NullReferenceException();
        }


    }
}

