using final_project.models;
using final_project.models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace final_project.BL
{
    public class GiftService:IGiftService
    {
        private readonly ApplicationDbContext _context;
        public GiftService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GiftDTO>> GetAllGiftsAsync()
        {
        
     
                return await _context.Gifts
                .Select(g => new GiftDTO
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    Price = g.Price,
                    CategoryID = g.CategoryID
                })
                .ToListAsync();
            
            

        }

        public async Task<GiftDTO> GetGiftByIdAsync(int id)
        {
            var g = await _context.Gifts.FindAsync(id);
            if (g ==null) throw new Exception("there is no gift by this id");

            return new GiftDTO
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Price = g.Price,
                CategoryID = g.CategoryID
            };
        }

        public async Task AddGiftAsync(GiftDTO giftDto)
        {
            var gift = new Gift
            {
                Name = giftDto.Name,
                Description = giftDto.Description,
                Price = giftDto.Price,
                CategoryID = giftDto.CategoryID,
            };
            _context.Gifts.Add(gift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGiftAsync(int id, GiftDTO giftDto)
        {
            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null) return;
            gift.Name = giftDto.Name;
            gift.Description = giftDto.Description;
            gift.CategoryID = giftDto.CategoryID;
            gift.Price = giftDto.Price;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteGiftAsync(int id)
        {
            var gift = await _context.Gifts.FindAsync(id);
            if (gift == null) return;
            _context.Gifts.Remove(gift);
            await _context.SaveChangesAsync();
        }




    }
}
