using System.Threading.Tasks;

namespace final_project.BL
{
    public interface IReportsService
    {
        Task<decimal> GetTotalIncomeAsync();
    }
}
