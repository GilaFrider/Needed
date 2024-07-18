using Services;
using Services.Api_Service;
using Services.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly IEmployerService employerService;
        public EmployersController(ManagerService manager)
        {
            employerService = manager.employerServices;
        }
        [HttpGet("login")]
        public ActionResult<EmployerDTO> Login(String email,String password)
        {
            var employer = employerService.GetAll()
                .FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employer == null)
            {
                return Unauthorized();
            }
            return employer;
        }
        [HttpGet]
        public ActionResult<List<EmployerDTO>> GetAll()
        {
            List<EmployerDTO> get = employerService.GetAll();
            if (get == null)
            {
                return NotFound();
            }
            return get;

        }
        [HttpPost]
        public ActionResult<EmployerDTO> Create([FromBody] EmployerDTO employerDTO)
        {
            try
            {
                var createdEmployer = employerService.Create(employerDTO);

                return createdEmployer;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the job.");
            }
        }
   

        [HttpPut("{code}")]
        public ActionResult<EmployerDTO> Update(int code, EmployerDTO updatedJobDTO)
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
        public ActionResult<EmployerDTO> Delete(int code)
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
        [HttpGet("{code}")]
        public ActionResult<EmployerDTO> GetByCode(int code)
        {
            var employer = employerService.GetByCode(code);
            if (employer == null)
            {
                return NotFound();
            }

            return employer;
        }
    }

}

