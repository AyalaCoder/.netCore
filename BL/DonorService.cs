using final_project.models;
using final_project.models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class DonorService
    {
        private readonly ApplicationDbContext _context;
        public DonorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DonorDTO>> GetAllDonorAsync()
        {
            return await _context.Donors
                .Select(g=>new DonorDTO
                {
                   Id=g.Id,
                   Name=g.Name,
                   Email=g.Email,
                   Phone=g.Phone

                })
                 .ToListAsync();

        }

        public async Task<DonorDTO> GetDonorByIdAsync(int id)
        {
            var g = await _context.Donors.FindAsync(id);
            if (g == null) return null;
            return new DonorDTO { 
                Id = g.Id, 
                Name = g.Name,
                Email = g.Email,
                Phone = g.Phone };   
        }

        public async Task AddDonorAsync(DonorDTO donorDto)
        {
            var donor = new Donor
            {
                Name = donorDto.Name,
                Email = donorDto.Email,
                Phone = donorDto.Phone
            };
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDonorAsync(int id, DonorDTO donorDto)
        {
            var g = await _context.Donors.FindAsync(id);
            if (g == null) return;
            g.Name = donorDto.Name;
            g.Email = donorDto.Email;
            g.Phone = donorDto.Phone;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDonorAsync(int id)
        {
            var g = await _context.Donors.FindAsync(id);
            if (g == null) return;
            _context.Donors.Remove(g);
            await _context.SaveChangesAsync();

        }
        
       
    }
}
