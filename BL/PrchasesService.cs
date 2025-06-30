using final_project.models;
using final_project.models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext _context;
        public PurchaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddPurchaseAsync(PurchaseDTO dto, int userId)
        {
            var purchase = new Purchase
            {
                GiftId = dto.GiftId,
                Quantity = dto.Quantity,
                UserId = userId,
                CreatedAt = DateTime.Now
            };

            _context.Purchase.Add(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchase
                .Include(p => p.Gift)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<List<Purchase>> GetByGiftIdAsync(int giftId)
        {
            return await _context.Purchase
                .Where(p => p.GiftId == giftId)
                .ToListAsync();
        }
    }
}

