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
        public ActionResult<List<CriterionDTO>> GetAll()
        {
            var criterions = _criterionService.GetAll();
            return criterions;
        }

        [HttpPost]
        public ActionResult<CriterionDTO> Create([FromBody] CriterionDTO criterion)
        {
            if (criterion == null)
            {
                return BadRequest();
            }

            var createdCriterion = _criterionService.Create(criterion);
            return createdCriterion;
        }

        [HttpDelete("{code}")]
        public ActionResult<CriterionDTO> Delete(int code)
        {
            var deletedCriterion = _criterionService.Delete(code);
            if (deletedCriterion == null)
            {
                return NotFound();
            }

            return deletedCriterion;
        }

        [HttpPut("{code}")]
        public ActionResult<CriterionDTO> Update(int code, [FromBody] CriterionDTO criterion)
        {
            if (criterion == null || criterion.Code != code)
            {
                return BadRequest();
            }

            var updatedCriterion = _criterionService.Update(code, criterion);
            return updatedCriterion;
        }

        [HttpGet("{code}")]
        public ActionResult<CriterionDTO> GetByCode(int code)
        {
            var criterion = _criterionService.GetByCode(code);
            if (criterion == null)
            {
                return NotFound();
            }

            return criterion;
        }
    }
}
