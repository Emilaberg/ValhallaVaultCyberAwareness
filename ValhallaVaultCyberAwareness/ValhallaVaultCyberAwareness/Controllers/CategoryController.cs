using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IValhallaUow _uow;
        public CategoryController(IValhallaUow uow)
        {

            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
        {
            var categories = await _uow.CategoryRepo.GetAllCategories();

            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            var result = await _uow.CategoryRepo.GetCategoryById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> AddCategory(CategoryModel category)
        {
            var newCategory = await _uow.CategoryRepo.AddCategory(category);

            if (newCategory != null)
            {
                return Ok(newCategory);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryModel>> DeleteCategory(int id)
        {
            var result = await _uow.CategoryRepo.DeleteCategory(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryModel>> UpdateCategory(CategoryModel category)
        {
            var updatedCategory = await _uow.CategoryRepo.UpdateCategory(category);

            if (updatedCategory != null)
            {
                return Ok(updatedCategory);
            }
            return NotFound();
        }

    }
}
