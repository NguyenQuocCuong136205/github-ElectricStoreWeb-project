using ElectriStore_BaseProject.DTOs.Suppliers;
using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Services.Suppliers
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int id);
        Task<SupplierResultDTO> CreateSupplierAsync(Supplier supplier);
        Task<SupplierResultDTO> EditSupplierAsync(Supplier supplier);
        Task<SupplierResultDTO> DeleteSupplierAsync(int id);
    }
}
