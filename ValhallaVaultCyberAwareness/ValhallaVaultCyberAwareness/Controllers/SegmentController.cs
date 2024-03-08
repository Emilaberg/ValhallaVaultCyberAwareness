using Microsoft.AspNetCore.Mvc;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVaultCyberAwareness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {

        private readonly IValhallaUow _uow;


        public SegmentController(IValhallaUow uow)
        {

            _uow = uow;

        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentModel>>> GetAllSegments()
        {
            var segments = await _uow.SegmentRepo.GetAllSegments();
            if (segments != null)
            {
                return Ok(segments);
            }
            return NotFound();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SegmentModel>> GetSegmentById(int id)
        {
            var result = await _uow.SegmentRepo.GetSegmentById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SegmentModel>> AddSegmenty(SegmentModel segment)
        {
            var newSegment = await _uow.SegmentRepo.AddSegment(segment);

            if (newSegment != null)
            {
                return Ok(newSegment);
            }
            return NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SegmentModel>> DeleteSegment(int id)
        {
            var result = await _uow.SegmentRepo.DeleteSegment(id);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPut]
        public async Task<ActionResult<SegmentModel>> UpdateSegment(SegmentModel segment)
        {
            var updatedSegment = await _uow.SegmentRepo.UpdateSegment(segment);

            if (updatedSegment != null)
            {
                return Ok(updatedSegment);
            }
            return NotFound();
        }

    }
}
