using Microsoft.AspNetCore.Mvc;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.Services.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        [HttpPost("MetodoPost")]
        public async Task<ActionResult> Post([FromBody] Object data)
        {
            try
            {
                PersonDTO personDTO = JsonSerializer.Deserialize<PersonDTO>(data.ToString());
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

        [HttpPost("MetodoGet")]
        public async Task<ActionResult> GetAsync([FromBody] Object data)
        {
            try
            {
                PersonDTO personDTO = JsonSerializer.Deserialize<PersonDTO>(data.ToString());
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
    }
}
