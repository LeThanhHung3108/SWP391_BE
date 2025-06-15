using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_Repository.Repository
{
    public class VaccScheduleRepository : IVaccScheduleRepository
    {
        private readonly ApplicationDBContext _context;

        public VaccScheduleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //1. Get all vaccination schedules
        public async Task<IEnumerable<StudentVaccinationSchedule>> GetAllVaccSchedulesAsync()
        {
            return await _context.StudentVaccinationSchedules
                .Include(vs => vs.VaccinationCampaign)
                .Include(vs => vs.Student)
                .ToListAsync();
        }

        //2. Get vaccination schedule by ID
        public async Task<StudentVaccinationSchedule> GetVaccScheduleByIdAsync(Guid vaccScheduleId)
        {
            return await _context.StudentVaccinationSchedules
                .Include(vs => vs.VaccinationCampaign)
                .Include(vs => vs.Student)
                .FirstOrDefaultAsync(vs => vs.Id == vaccScheduleId);
        }

        //3. Get vaccination schedules by Campaign ID
        public async Task<IEnumerable<StudentVaccinationSchedule>> GetVaccSchedulesByCampaignIdAsync(Guid vaccCampaignId)
        {
            return await _context.StudentVaccinationSchedules
                .Include(vs => vs.VaccinationCampaign)
                .Include(vs => vs.Student)
                .Where(vs => vs.CampaignId == vaccCampaignId)
                .ToListAsync();
        }

        //4. Create a new vaccination schedule
        public async Task CreateVaccScheduleAsync(StudentVaccinationSchedule vaccSchedule)
        {
            await _context.StudentVaccinationSchedules.AddAsync(vaccSchedule);
            await _context.SaveChangesAsync();
        }

        //5. Update an existing vaccination schedule
        public async Task UpdateVaccScheduleAsync(StudentVaccinationSchedule vaccSchedule)
        {
            _context.Entry(vaccSchedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //6. Delete a vaccination schedule
        public async Task DeleteVaccScheduleAsync(Guid vaccScheduleId)
        {
            var vaccSchedule = await GetVaccScheduleByIdAsync(vaccScheduleId);

            if (vaccSchedule != null)
            {
                _context.StudentVaccinationSchedules.Remove(vaccSchedule);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}