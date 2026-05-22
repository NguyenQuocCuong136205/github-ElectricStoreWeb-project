using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Repositories.Suppliers
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(int id);
        Task<Supplier?> GetSupplierByNameAsync(string name);
        Task<bool> CreateSupplierAsync(Supplier supplier);
        Task<bool> EditSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
