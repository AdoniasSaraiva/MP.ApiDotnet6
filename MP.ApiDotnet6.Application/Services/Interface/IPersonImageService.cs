using MP.ApiDotnet6.Application.DTOs;

namespace MP.ApiDotnet6.Application.Services.Interface
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDTO);

        Task<ResultService> CreateImageAsync(PersonImageDTO personImageDTO);

    }
}
