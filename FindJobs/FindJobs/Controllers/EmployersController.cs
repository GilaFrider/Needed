using Bl.Bl_Api;
using Bl.DTO;
using Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        IBlEmployer blEmployer;
        public EmployersController(BlManager manager)
        {
            blEmployer = manager.employerServices;
        }
        [HttpGet]
        public ActionResult<List<EmployerDTO>> GetAll()
        {
            List<EmployerDTO> get = blEmployer.GetAll();
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
                var createdEmployer = blEmployer.Create(employerDTO);

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
                var updatedEmployer = blEmployer.Update(code, updatedJobDTO);
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
                var deletedEmployer = blEmployer.Delete(code);
                return deletedEmployer;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}

