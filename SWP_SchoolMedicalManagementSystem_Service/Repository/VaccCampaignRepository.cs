using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository
{
    public class VaccCampaignRepository : IVaccCampaignRepository
    {
        private readonly ApplicationDBContext _context;

        public VaccCampaignRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //1. Get all vaccination campaigns
        public async Task<IEnumerable<VaccinationCampaign>> GetAllVaccCampaignsAsync()
        {
            return await _context.VaccinationCampaigns
                .Include(v => v.Schedules)
                .ToListAsync();
        }

        //2. Get vaccination campaign by ID
        public async Task<VaccinationCampaign?> GetVaccCampaignByIdAsync(Guid vaccCampaignId)
        {
            return await _context.VaccinationCampaigns
                .Include(v => v.Schedules)
                .FirstOrDefaultAsync(v => v.Id == vaccCampaignId);
        }

        //3. Get vaccination campaigns by status
        public async Task<IEnumerable<VaccinationCampaign>> GetCampaignsByStatusAsync(VaccCampaignStatus vaccCampaigStatus)
        {
            return await _context.VaccinationCampaigns
                .Include(v => v.Schedules)
                .Where(v => v.Status == vaccCampaigStatus)
                .AsNoTracking()
                .ToListAsync();
        }

        //4. Create vaccination campaign
        public async Task CreateCampaignAsync(VaccinationCampaign vaccCampaign)
        {
            await _context.VaccinationCampaigns.AddAsync(vaccCampaign);
            await _context.SaveChangesAsync();
        }

        //5. Update vaccination campaign
        public async Task UpdateCampaignAsync(VaccinationCampaign vaccCampaign)
        {
            _context.Entry(vaccCampaign).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //6. Delete vaccination campaign
        public async Task DeleteCampaignAsync(Guid vaccCampaignId)
        {
            var vaccCampaign = await GetVaccCampaignByIdAsync(vaccCampaignId);
            if (vaccCampaign != null)
            {
                _context.VaccinationCampaigns.Remove(vaccCampaign);
                await _context.SaveChangesAsync();
            }
        }
    }
}
