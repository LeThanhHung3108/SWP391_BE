using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IMedicalSupplierRepository
    {
        Task CreateSupplierAsync(MedicalSupplier supplier);
        Task UpdateSupplierAsync(MedicalSupplier supplier);
        Task DeleteSupplierAsync(Guid id);
        Task<MedicalSupplier?> GetSupplierByIdAsync(Guid id);
        Task<IEnumerable<MedicalSupplier>> GetAllSuppliersAsync();
    }
}
