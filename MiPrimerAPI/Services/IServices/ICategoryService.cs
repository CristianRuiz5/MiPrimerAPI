using MiPrimerAPI.DataAccessLayer.Dtos.Category;
using MiPrimerAPI.DataAccessLayer.Models;

namespace MiPrimerAPI.Services.iServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
    }

}
