using Bl;
using Bl.Bl_Api;
using Bl.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FindJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IBlJob _jobService;

        public JobsController(BlManager manager)
        {
            _jobService = manager.jobServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobDTO>> GetAllJobs()
        {
            try
            {
                var jobs = _jobService.GetAll();
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{code}")]
        public ActionResult<JobDTO> GetJobByCode(int code)
        {
            try
            {
                var job = _jobService.GetAll().FirstOrDefault(j => j.Code == code);

                if (job == null)
                {
                    return NotFound();
                }
                return Ok(job);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] JobDTO jobDTO)
        {
            try
            {
                // Process job creation logic here (similar to your existing Create method)
                var createdJob = _jobService.Create(jobDTO);

                return Ok(createdJob); // Return a success response
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the job."); // Return an error response
            }
        }


        [HttpPut("{code}")]
        public ActionResult<JobDTO> UpdateJob(int code, JobDTO updatedJobDTO)
        {
            try
            {
                var updatedJob = _jobService.Update(code, updatedJobDTO);
                return Ok(updatedJob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{code}")]
        public ActionResult<JobDTO> DeleteJob(int code)
        {
            try
            {
                var deletedJob = _jobService.Delete(code);
                return Ok(deletedJob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
