using MP.ApiDotnet6.Application.DTOs;

namespace MP.ApiDotnet6.Application.Services.Interface
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO);
    }
}
