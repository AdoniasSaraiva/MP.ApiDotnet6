using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotNet6.Domain.FiltersDb;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Application.Services.Interface
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);

        Task<ResultService<PersonDTO>> GetByIdAsync(int id);

        Task<ResultService<ICollection<PersonDTO>>> GetAsync();

        Task<ResultService> UpdateAsync(PersonDTO personDTO);

        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
    }
}