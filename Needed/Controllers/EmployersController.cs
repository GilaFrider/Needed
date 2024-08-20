using Microsoft.AspNetCore.Mvc;
using Services.ApiService;
using Services.DTO;
using Services.ImplementationService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Needed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployersController(IEmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerDTO>>> GetAll()
        {
            var employers = await _employerService.GetAllAsync();
            return Ok(employers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerDTO>> GetById(int id)
        {
            var employer = await _employerService.GetByIdAsync(id);
            if (employer == null)
            {
                return NotFound();
            }
            return Ok(employer);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployerDTO employerDto)
        {
            if (employerDto == null)
            {
                return BadRequest("Employer data is null.");
            }

            await _employerService.CreateAsync(employerDto);
            return CreatedAtAction(nameof(GetById), new { id = employerDto.Code }, employerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmployerDTO employerDto)
        {
            if (id != employerDto.Code)
            {
                return BadRequest("ID mismatch.");
            }

            var existingEmployer = await _employerService.GetByIdAsync(id);
            if (existingEmployer == null)
            {
                return NotFound();
            }

            await _employerService.UpdateAsync(employerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employer = await _employerService.GetByIdAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            await _employerService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var employer = await _employerService.LoginAsync(email, password);

            if (employer == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(employer);
        }

        [HttpPost("send-cv/{employerId}")]
        public async Task<IActionResult> SendCV(int employerId, [FromForm] IFormFile cv, [FromForm] string message)
        {
            var employer = await _employerService.GetByIdAsync(employerId);
            if (employer == null)
            {
                return NotFound("Employer not found.");
            }

            if (cv == null || cv.Length == 0)
            {
                return BadRequest("A valid CV file is required.");
            }

            using (var stream = cv.OpenReadStream())
            {
                try
                {
                    await _employerService.SendCvAsync(employerId, stream, cv.FileName, message);
                }
                catch (Exception ex)
                {
                    // Log the error (not shown here)
                    return StatusCode(500, "An error occurred while sending the CV: " + ex.Message);
                }
            }

            return Ok("CV and message sent successfully!");
        }




    }


}
