using Services;
using Services.Api_Service;
using Services.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Security.Claims;

namespace FindJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly IEmployerService _employerService;

        public JobsController(ManagerService manager)
        {
            _jobService = manager.jobServices;
            _employerService = manager.employerServices;
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
        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult CreateJob([FromBody] JobDTO jobDTO)
        {

            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null)
                {
                    return Unauthorized();
                }
                var employer = _employerService.GetEmployerByEmail(email);
                if (employer == null)
                {
                    return NotFound("Employer not found.");
                }

                jobDTO.EmployersCode = employer.Code; // Assuming JobDTO has an EmployerCode property
                
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
