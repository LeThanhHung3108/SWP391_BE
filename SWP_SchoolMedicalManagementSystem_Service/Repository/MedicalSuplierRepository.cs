using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository
{
    public class MedicalSuplierRepository : IMedicalSupplierRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public MedicalSuplierRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task CreateSupplierAsync(MedicalSupplier supplier)
        {
            await _context.MedicalSuppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(Guid id)
        {
            var oldSupplier = await _context.MedicalSuppliers.FirstOrDefaultAsync(s => s.Id.Equals(id));
            _context.MedicalSuppliers.Remove(oldSupplier);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalSupplier>> GetAllSuppliersAsync()
        {
            var listSupplier = await _context.MedicalSuppliers.AsNoTracking().ToListAsync();
            return listSupplier;
        }

        public async Task<MedicalSupplier?> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _context.MedicalSuppliers.FirstOrDefaultAsync(s => s.Id.Equals(id));
            return supplier;
        }

        public async Task UpdateSupplierAsync(MedicalSupplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
