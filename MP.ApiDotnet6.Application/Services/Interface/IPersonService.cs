using MP.ApiDotnet6.Application.DTOs;

namespace MP.ApiDotnet6.Application.Services.Interface
{
    public interface IPersonService
    {
         Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
    }
}