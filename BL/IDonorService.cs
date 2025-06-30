using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IDonorService
    {
        Task<List<DonorDTO>> GetAllDonorAsync();
        Task<DonorDTO> GetDonorByIdAsync(int id);
        Task AddDonorAsync(DonorDTO donorDto);
        Task UpdateDonorAsync(int id, DonorDTO donorDto);
        Task DeleteDonorAsync(int id);

    }
}
