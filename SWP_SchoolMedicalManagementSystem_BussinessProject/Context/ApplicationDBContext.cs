using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Context
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext()
        {
        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HealthCheckupCampaign> HealthCheckupCampaigns { get; set; }
        public DbSet<HealthCheckupConsentForm> HealthCheckupConsentForms { get; set; }
        public DbSet<HealthCheckupResults> HealthCheckupResults { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<MedicalConsultation> MedicalConsultations { get; set; }
        public DbSet<MedicalIncident> MedicalIncidents { get; set; }
        public DbSet<MedicalSupplier> MedicalSuppliers { get; set; }
        public DbSet<MedicalSupplyUsage> MedicalSupplyUsages { get; set; }
        public DbSet<MedicationRequests> MedicationRequests { get; set; }
        public DbSet<StudentHealthCheckupSchedule> StudentHealthCheckupSchedules { get; set; }
        public DbSet<StudentVaccinationSchedule> StudentVaccinationSchedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<VaccinationCampaign> VaccinationCampaigns { get; set; }
        public DbSet<VaccinationConsentForm> VaccinationConsentForms { get; set; }
        public DbSet<VaccinationResults> VaccinationResults { get; set; }
        public DbSet<MedicalDiary> MedicalDiaries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(options =>
            {
                options.HasMany(u => u.Blogs)
                    .WithOne(b => b.Author)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(u => u.MedicalConsultations)
                    .WithOne(m => m.MedicalStaff)
                    .HasForeignKey(m => m.MedicalStaffId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(u => u.MedicationRequests)
                    .WithOne(m => m.MedicalStaff)
                    .HasForeignKey(m => m.MedicalStaffId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(u => u.Students)
                    .WithOne(s => s.Parent)
                    .HasForeignKey(s => s.ParentId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Student>(options =>
            {
                options.HasMany(s => s.HealthCheckupSchedules)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.VaccinationSchedules)
                    .WithOne(v => v.Student)
                    .HasForeignKey(v => v.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.MedicationRequests)
                    .WithOne(m => m.Student)
                    .HasForeignKey(m => m.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.CheckupConsentForms)
                    .WithOne(c => c.Student)
                    .HasForeignKey(c => c.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.VaccinationConsentForms)
                    .WithOne(v => v.Student)
                    .HasForeignKey(v => v.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.MedicalIncidents)
                    .WithOne(m => m.Student)
                    .HasForeignKey(m => m.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasMany(s => s.MedicalConsultations)
                    .WithOne(m => m.Student)
                    .HasForeignKey(m => m.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<MedicalSupplyUsage>(options =>
            {
                options.HasKey(msu => new { msu.SupplyId, msu.IncidentId });

                options.HasOne(msu => msu.MedicalSupply)
                    .WithMany(ms => ms.MedicalSupplyUsages)
                    .HasForeignKey(msu => msu.SupplyId)
                    .OnDelete(DeleteBehavior.NoAction);

                options.HasOne(msu => msu.Incident)
                    .WithMany(mi => mi.MedicalSupplyUsages)
                    .HasForeignKey(msu => msu.IncidentId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<MedicationRequests>(options =>
            {
                options.HasMany(m => m.MedicalDiaries)
                    .WithOne(md => md.MedicationReq)
                    .HasForeignKey(md => md.MedicationReqId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}