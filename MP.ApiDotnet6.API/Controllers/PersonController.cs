using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.FiltersDb;
using System.Collections.Generic;

namespace MP.ApiDotnet6.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly ICurrentUser _currentUser;
        private List<string> _permissionNeeded = new List<string>() { "Admin" };
        private readonly List<string> _permissionUser;


        public PersonController(IPersonService personService, ICurrentUser currentUser)
        {
            _personService = personService;
            _currentUser = currentUser;
            _permissionUser = _currentUser.Permissions?.Split(",").ToList() ?? new List<string>();
        }

        [HttpPost("CreatePersonAsync")]
        public async Task<IActionResult> CreateProductAsync(PersonDTO personDTO)
        {
            _permissionNeeded.Add("CreatePerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.CreateAsync(personDTO);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync()
        {
            _permissionNeeded.Add("GetPerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(PersonDTO personDTO)
        {
            _permissionNeeded.Add("GetPerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetByIdAsync(personDTO.Id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("EditAsync")]
        public async Task<IActionResult> EditAsync(PersonDTO personDTO)
        {
            _permissionNeeded.Add("UpdatePerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.UpdateAsync(personDTO);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(PersonDTO personDTO)
        {
            _permissionNeeded.Add("DeletePerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.DeleteAsync(personDTO.Id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PersonFilterDb personFilterDb)
        {
            _permissionNeeded.Add("GetPerson");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetPagedAsync(personFilterDb);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
