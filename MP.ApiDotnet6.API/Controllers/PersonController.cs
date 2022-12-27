using Microsoft.AspNetCore.Mvc;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.Services.Interface;

namespace MP.ApiDotnet6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("CreatePersonAsync")]
        public async Task<ActionResult> CreateProductAsync(PersonDTO personDTO)
        {
            try
            {
                var result = await _personService.CreateAsync(personDTO);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAsync")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var result = await _personService.GetAsync();

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByIdAsync")]
        public async Task<ActionResult> GetByIdAsync(PersonDTO personDTO)
        {
            try
            {
                var result = await _personService.GetByIdAsync(personDTO.Id);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditAsync")]
        public async Task<ActionResult> EditAsync(PersonDTO personDTO)
        {
            try
            {
                var result = await _personService.UpdateAsync(personDTO);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAsync")]
        public async Task<ActionResult> DeleteAsync(PersonDTO personDTO)
        {
            try
            {
                var result = await _personService.DeleteAsync(personDTO.Id);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
