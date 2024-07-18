using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Api_Service;
using Services.DTO;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(ManagerService managerService)
        {
            _jobService = managerService.jobServices;
        }

        [HttpPost]
        public ActionResult Create([FromBody] JobDTO jobDto)
        {
            if (jobDto == null)
            {
                return BadRequest("JobDTO is null.");
            }

            var createdJob = _jobService.Create(jobDto);
            return CreatedAtAction(nameof(GetJobByCode), new { code = createdJob.Code }, createdJob);
        }

        [HttpDelete("{code}")]
        public ActionResult<JobDTO> DeleteJob(int code)
        {
            var success = _jobService.Delete(code);
            if (success != null)
            {
                return success;
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<JobDTO>> GetAllJobs()
        {
            var jobs = _jobService.GetAll();
            return jobs;
        }

        [HttpGet("{code}")]
        public ActionResult<JobDTO> GetJobByCode(int code)
        {
            var job = _jobService.GetByCode(code);
            if (job != null)
            {
                return job;
            }
            return NotFound();
        }

        [HttpPut("{code}")]
        public ActionResult<JobDTO> UpdateJob(int code, [FromBody] JobDTO jobDto)
        {
            if (jobDto == null || jobDto.Code != code)
            {
                return BadRequest("JobDTO is null or code mismatch.");
            }

            var updatedJob = _jobService.Update(code, jobDto);
            if (updatedJob != null)
            {
                return updatedJob;
            }
            return NotFound();
        }
    }
}
