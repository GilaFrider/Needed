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
    public class JobController : ControllerBase
    {
        private readonly IBlJob _jobService;

        public JobController(BlManager manager)
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
        public ActionResult<JobDTO> CreateJob(JobDTO jobDTO)
        {
            try
            {
                var createdJob = _jobService.Create(jobDTO);
                return CreatedAtAction(nameof(GetJobByCode), new { code = createdJob.Code }, createdJob);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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
