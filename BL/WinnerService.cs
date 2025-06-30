using final_project.models;
using final_project.models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class WinnerService : IWinnerService
    {
        private readonly ApplicationDbContext _context;

        public WinnerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WinnerReportDTO>> GetWinnerReportAsync()
        {
            return await _context.Gifts
                .Where(g => g.WinnerID != null)
                .Include(g => g.Purchases)
                .Include(g => g.Purchases.Select(p => p.User))
                .Join(_context.Users,
                      g => g.WinnerID,
                      u => u.Id,
                      (g, u) => new WinnerReportDTO
                      {
                          GiftName = g.Name,
                          UserName = u.Name
                      })
                .ToListAsync();
        }
    }
}
