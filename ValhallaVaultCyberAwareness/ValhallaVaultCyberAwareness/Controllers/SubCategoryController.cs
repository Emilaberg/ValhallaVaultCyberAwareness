using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase

    {

        private readonly IValhallaUow _uow;


        public SubCategoryController(IValhallaUow uow)
        {

            _uow = uow;

        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryModel>>> GetAllsubCategorys()
        {
            var subCategories = await _uow.SubCategoryRepo.GetAllSubCategories();
            if (subCategories != null)
            {
                return Ok(subCategories);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SubCategoryModel>> GetSubCategoryById(int id)
        {
            var result = await _uow.SubCategoryRepo.GetSubCategoryById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryModel>> AddSubCategory(SubCategoryModel subCategory)
        {
            var newSubCategory = await _uow.SubCategoryRepo.AddSubCategory(subCategory);

            if (newSubCategory != null)
            {
                return Ok(newSubCategory);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SubCategoryModel>> DeleteSubCategory(int id)
        {
            var result = await _uow.SubCategoryRepo.DeleteSubCategory(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut]
        public async Task<ActionResult<SubCategoryModel>> UpdateSubCategory(SubCategoryModel category)
        {
            var updatedSubCategory = await _uow.SubCategoryRepo.UpdateSubCategory(category);

            if (updatedSubCategory != null)
            {
                return Ok(updatedSubCategory);
            }
            return NotFound();
        }

    }
}

