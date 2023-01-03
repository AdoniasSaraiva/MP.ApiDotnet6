using Microsoft.AspNetCore.Mvc;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.Services.Interface;

namespace MP.ApiDotnet6.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {
            _personImageService = personImageService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageBase64Async(personImageDTO);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("PathImage")]
        public async Task<IActionResult> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageAsync(personImageDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
