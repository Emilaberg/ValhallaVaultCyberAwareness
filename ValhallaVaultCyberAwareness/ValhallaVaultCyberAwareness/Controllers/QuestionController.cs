using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly ValhallaUow _uow;


        public QuestionController(ValhallaUow uow)
        {
            _uow = uow;

        }
        [HttpGet]
        public async Task<ActionResult<List<QuestionModel>>> GetAllquestion()
        {
            var question = await _uow.QuestionRepo.GetAllQuestions();
            if (question != null)
            {
                return Ok(question);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<QuestionModel>> GetquestionById(int id)
        {
            var result = await _uow.QuestionRepo.GetQuestionById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<QuestionModel>> Addquestion(QuestionModel question)
        {
            var newquestion = await _uow.QuestionRepo.AddQuestion(question);

            if (newquestion != null)
            {
                return Ok(newquestion);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionModel>> Deletequestion(int id)
        {
            var result = await _uow.QuestionRepo.DeleteQuestion(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut]
        public async Task<ActionResult<QuestionModel>> Updatequestion(QuestionModel updatedquestion)
        {
            if (updatedquestion != null)
            {
                await _uow.QuestionRepo.UpdateQuestion(updatedquestion);
                return Ok(updatedquestion);
            }
            return NotFound();
        }
    }
}
