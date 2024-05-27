using Bl;
using Bl.Bl_Api;
using Bl.Bl_Implementation;
using Bl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsOfWorkController : ControllerBase
    {
        IBlFieldOfWork blFieldOfWork;
        public FieldsOfWorkController(BlManager manager)
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
