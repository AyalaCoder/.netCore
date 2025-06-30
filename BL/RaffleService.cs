using final_project.models;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class RaffleService : IRaffleService
    {
        private readonly ApplicationDbContext _context;

        public RaffleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int?> RaffleGiftAsync(int giftId)
        {
            var purchases = await _context.Purchase
                .Where(p => p.GiftId == giftId)
                .ToListAsync();

            if (purchases.Count == 0)
                return null;

            var random = new Random();
            var winner = purchases[random.Next(purchases.Count)];

            var gift = await _context.Gifts.FindAsync(giftId);
            gift.WinnerID = winner.UserId;

            await _context.SaveChangesAsync();

            return winner.UserId;
        }
    }
}
