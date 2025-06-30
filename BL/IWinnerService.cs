using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IWinnerService
    {
        Task<List<WinnerReportDTO>> GetWinnerReportAsync();
    }
}
