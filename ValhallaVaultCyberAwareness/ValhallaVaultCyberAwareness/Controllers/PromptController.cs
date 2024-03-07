using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {

        private readonly IValhallaUow _uow;

        public PromptController(IValhallaUow uow)
        {

            _uow = uow;

        }

        [HttpGet]
        public async Task<ActionResult<List<PromptModel>>> GetAllCategories()
        {
            var categories = await _uow.PromptRepo.GetAllPrompts();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<PromptModel>> GetPromptById(int id)
        {
            var result = await _uow.PromptRepo.GetPromptById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PromptModel>> AddPrompt(PromptModel Prompt)
        {
            var newPrompt = await _uow.PromptRepo.AddPrompt(Prompt);

            if (newPrompt != null)
            {
                return Ok(newPrompt);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PromptModel>> DeletePrompt(int id)
        {
            var result = await _uow.PromptRepo.DeletePrompt(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut]
        public async Task<ActionResult<PromptModel>> UpdatePrompt(PromptModel updatedPrompt)
        {
            if (updatedPrompt != null)
            {
                await _uow.PromptRepo.UpdatePrompt(updatedPrompt);
                return Ok(updatedPrompt);
            }
            return NotFound();
        }
    }
}
