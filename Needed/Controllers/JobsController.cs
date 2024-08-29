using Microsoft.AspNetCore.Mvc;
using Services.ApiService;
using Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Needed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> GetAll()
        {
            var jobs = await _jobService.GetAllAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobDTO>> GetById(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] JobDTO jobDto)
        {
            if (jobDto == null)
            {
                return BadRequest("Job data is null.");
            }

            await _jobService.CreateAsync(jobDto);
            return CreatedAtAction(nameof(GetById), new { id = jobDto.Code }, jobDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] JobDTO jobDto)
        {

            //try
            //{
                var existingJob = await _jobService.GetByIdAsync(id);
                if (existingJob == null)
                {
                    return NotFound();
                }

                await _jobService.UpdateAsync(jobDto);
                return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception here (e.g., using a logging framework)
            //    return StatusCode(500, "An error occurred while updating the job. Please try again later.");
            //}
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var job = await _jobService.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            await _jobService.DeleteAsync(id);
            return NoContent();
        }
    }
}
