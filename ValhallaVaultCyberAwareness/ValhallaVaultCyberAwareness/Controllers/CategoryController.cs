using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [Route("api/[controller]")]
        [ApiController]
        public class TicketsController : ControllerBase
        {

            //Inject Repository to access Methods 

            private readonly CategoryRepository _categoryRepo;


            public TicketsController(CategoryRepository categoryRepo)
            {
                _categoryRepo = categoryRepo;

            }

            [HttpGet]
            public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
            {
                var categories = await _categoryRepo.GetAllCategories();
                if (categories != null)
                {
                    return Ok(categories);
                }
                return NotFound();
            }

            [HttpGet("{id}")]

            public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
            {
                var result = await _categoryRepo.GetCategoryById(id);

                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            [HttpPost]
            public async Task<ActionResult<CategoryModel>> AddCategory(CategoryModel category)
            {
                var newCategory = await _categoryRepo.AddCategory(category);

                if (newCategory != null)
                {
                    return Ok(newCategory);
                }
                return NotFound();
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult<CategoryModel>> DeleteCategory(int id)
            {
                var result = await _categoryRepo.DeleteCategory(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();

            }

            [HttpPut]
            public async Task<ActionResult<CategoryModel>> UpdateCategory(CategoryModel updatedCategory)
            {
                if (updatedCategory != null)
                {
                    await _categoryRepo.UpdateCategory(updatedCategory);
                    return Ok(updatedCategory);
                }
                return NotFound();
            }
        }
    }
}
