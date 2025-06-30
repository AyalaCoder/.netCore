using final_project.models;
using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IPurchaseService
    {
        Task AddPurchaseAsync(PurchaseDTO dto, int userId);
        Task<List<Purchase>> GetAllPurchasesAsync();
        Task<List<Purchase>> GetByGiftIdAsync(int giftId);
    }
}

