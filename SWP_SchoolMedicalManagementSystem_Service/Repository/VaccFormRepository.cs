using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_Repository.Repository
{
    public class VaccFormRepository : IVaccFormRepository
    {
        private readonly ApplicationDBContext _context;

        public VaccFormRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //1. Get all vaccination consent forms
        public async Task<List<VaccinationConsentForm>> GetAllVaccFormsAsync()
        {
            return await _context.VaccinationConsentForms
                .Include(vf => vf.VaccinationCampaign)
                .Include(vf => vf.Student)
                .ToListAsync();
        }

        //2. Get vaccination consent form by ID
        public async Task<VaccinationConsentForm> GetVaccFormByIdAsync(Guid vaccFormId)
        {
            return await _context.VaccinationConsentForms
                .Include(vf => vf.VaccinationCampaign)
                .Include(vf => vf.Student)
                .FirstOrDefaultAsync(vf => vf.Id == vaccFormId);
        }

        //3. Get vaccination consent forms by campaign ID
        public async Task<List<VaccinationConsentForm>> GetVaccFormsByCampaignIdAsync(Guid vaccCampaignId)
        {
            return await _context.VaccinationConsentForms
                .Include(vf => vf.VaccinationCampaign)
                .Include(vf => vf.Student)
                .Where(vf => vf.CampaignId == vaccCampaignId)
                .ToListAsync();
        }

        //4. Get vaccination consent forms by student ID
        public async Task<List<VaccinationConsentForm>> GetVaccFormsByStudentIdAsync(Guid studentId)
        {
            return await _context.VaccinationConsentForms
                .Include(vf => vf.VaccinationCampaign)
                .Include(vf => vf.Student)
                .Where(vf => vf.StudentId == studentId)
                .ToListAsync();
        }

        //5. Create a new vaccination consent form
        public async Task CreateVaccFormAsync(VaccinationConsentForm vaccForm)
        {
            await _context.VaccinationConsentForms.AddAsync(vaccForm);
            await _context.SaveChangesAsync();
        }

        //6. Update an existing vaccination consent form
        public async Task UpdateVaccFormAsync(VaccinationConsentForm vaccForm)
        {
            _context.Entry(vaccForm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //7. Delete a vaccination consent form
        public async Task DeleteVaccFormAsync(Guid vaccFormId)
        {
            var vaccForm = await GetVaccFormByIdAsync(vaccFormId);
            if (vaccForm != null)
            {
                _context.VaccinationConsentForms.Remove(vaccForm);
                await _context.SaveChangesAsync();
            }
        }
    }
}