using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Api_Service;
using Services.DTO;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriterionController : ControllerBase
    {
        private readonly ICriterionService _criterionService;

        public CriterionController(ManagerService manager)
        {
            _criterionService = manager.criterionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var criterions = _criterionService.GetAll();
            return Ok(criterions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CriterionDTO criterion)
        {
            if (criterion == null)
            {
                return BadRequest();
            }

            var createdCriterion = _criterionService.Create(criterion);
            return CreatedAtAction(nameof(GetByCode), new { code = createdCriterion.Code }, createdCriterion);
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(int code)
        {
            var deletedCriterion = _criterionService.Delete(code);
            if (deletedCriterion == null)
            {
                return NotFound();
            }

            return Ok(deletedCriterion);
        }

        [HttpPut("{code}")]
        public IActionResult Update(int code, [FromBody] CriterionDTO criterion)
        {
            if (criterion == null || criterion.Code != code)
            {
                return BadRequest();
            }

            var updatedCriterion = _criterionService.Update(code, criterion);
            return Ok(updatedCriterion);
        }

        [HttpGet("{code}")]
        public IActionResult GetByCode(int code)
        {
            var criterion = _criterionService.GetByCode(code);
            if (criterion == null)
            {
                return NotFound();
            }

            return Ok(criterion);
        }
    }
}
