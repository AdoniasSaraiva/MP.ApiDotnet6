using MP.ApiDotnet6.Application.DTOs;

namespace MP.ApiDotnet6.Application.Services.Interface
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailsDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailsDTO>>> GetAsync();
        Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
