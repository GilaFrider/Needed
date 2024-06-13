using Services;
using Services.Api_Service;
using Services.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsOfWorkController : ControllerBase
    {
        IFieldOfWorkService blFieldOfWork;
        public FieldsOfWorkController(ManagerService manager)
        {
            blFieldOfWork = manager.fieldOfWorkServices;
        }
        [HttpGet]
        public ActionResult<List<FieldOfWorkDTO>> GetAll()
        {
            List<FieldOfWorkDTO> get = blFieldOfWork.GetAll();
            //if (get == null)
            //{
            //    return NotFound();
            //}
            return get;
        }
    }
}
