using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IGiftService
    {
        Task<List<GiftDTO>> GetAllGiftsAsync();
        Task<GiftDTO> GetGiftByIdAsync(int id);
        Task AddGiftAsync(GiftDTO giftDto);
        Task UpdateGiftAsync(int id, GiftDTO giftDto);
        Task DeleteGiftAsync(int id);
    }
}
