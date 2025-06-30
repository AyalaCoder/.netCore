using System.Linq;
using System.Threading.Tasks;
using final_project.models;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext _context;

        public ReportsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalIncomeAsync()
        {
            return await _context.Purchase
                .Include(p => p.Gift)
                .SumAsync(p => p.Quantity * p.Gift.Price);
        }
    }
}
