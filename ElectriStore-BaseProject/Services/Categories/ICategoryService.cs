using ElectriStore_BaseProject.DTOs.Categories;
using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<CategoryResultDTO> CreateCategoryAsync(Category category);
        Task<CategoryResultDTO> EditCategoryAsync(Category category);
        Task<CategoryResultDTO> DeleteCategoryAsync(int id);
    }
}
