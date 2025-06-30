namespace final_project.BL
{
    public interface IRaffleService
    {
        Task<int?> RaffleGiftAsync(int giftId);
    }
}
