using Microsoft.AspNetCore.Mvc;
using Services.ApiService;
using Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Needed.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldsOfWorkController : ControllerBase
    {
        private readonly IFieldsOfWorkService _fieldsOfWorkService;

        public FieldsOfWorkController(IFieldsOfWorkService fieldsOfWorkService)
        {
            _fieldsOfWorkService = fieldsOfWorkService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldsOfWorkDTO>>> GetAll()
        {
            var fieldsOfWork = await _fieldsOfWorkService.GetAllAsync();
            return Ok(fieldsOfWork);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FieldsOfWorkDTO>> GetById(int id)
        {
            var fieldOfWork = await _fieldsOfWorkService.GetByIdAsync(id);
            if (fieldOfWork == null)
            {
                return NotFound();
            }
            return Ok(fieldOfWork);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FieldsOfWorkDTO fieldsOfWorkDto)
        {
            if (fieldsOfWorkDto == null)
            {
                return BadRequest("Fields of Work data is null.");
            }

            await _fieldsOfWorkService.CreateAsync(fieldsOfWorkDto);
            return CreatedAtAction(nameof(GetById), new { id = fieldsOfWorkDto.Code }, fieldsOfWorkDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FieldsOfWorkDTO fieldsOfWorkDto)
        {
            if (id != fieldsOfWorkDto.Code)
            {
                return BadRequest("ID mismatch.");
            }

            var existingFieldOfWork = await _fieldsOfWorkService.GetByIdAsync(id);
            if (existingFieldOfWork == null)
            {
                return NotFound();
            }

            await _fieldsOfWorkService.UpdateAsync(fieldsOfWorkDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fieldOfWork = await _fieldsOfWorkService.GetByIdAsync(id);
            if (fieldOfWork == null)
            {
                return NotFound();
            }

            await _fieldsOfWorkService.DeleteAsync(id);
            return NoContent();
        }
    }
}
