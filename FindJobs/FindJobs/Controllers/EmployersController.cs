using Services;
using Services.Api_Service;
using Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        IEmployerService employerService;
        public EmployersController(ManagerService manager)
        {
            employerService = manager.employerServices;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            var employer = employerService.GetAll()
                .FirstOrDefault(e => e.Email == login.Email && e.Password == login.Password);

            if (employer == null)
            {
                return Unauthorized();
            }
            
            // Optional: Generate and return JWT token or any other response
            // var token = GenerateToken(employer.Email);
            // return Ok(new { Token = token });

            return Ok(new { Message = "Login successful!" });
        }
        [HttpGet]
        public ActionResult<List<EmployerDTO>> GetAll()
        {
            List<EmployerDTO> get = employerService.GetAll();
            //if (get == null)
            //{
            //    return NotFound();
            //}
            return get;

        }
        [HttpPost]
        public ActionResult<EmployerDTO> CreateEmployer([FromBody] EmployerDTO employerDTO)
        {
            try
            {
                // Process job creation logic here (similar to your existing Create method)
                var createdEmployer = employerService.Create(employerDTO);

                return createdEmployer; // Return a success response
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the job."); // Return an error response
            }
        }
   

        [HttpPut("{code}")]
        public ActionResult<EmployerDTO> UpdateJob(int code, EmployerDTO updatedJobDTO)
        {
            try
            {
                var updatedEmployer = employerService.Update(code, updatedJobDTO);
                return updatedEmployer;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{code}")]
        public ActionResult<EmployerDTO> DeleteJob(int code)
        {
            try
            {
                var deletedEmployer = employerService.Delete(code);
                return deletedEmployer;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}

