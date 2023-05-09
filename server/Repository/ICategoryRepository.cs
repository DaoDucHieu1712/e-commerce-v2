using BusinessObject.DTOs.Category;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
        Task<string> Create(CategoryCreateUpdateDTO categoryDTO);
        Task<string> Update(CategoryCreateUpdateDTO categoryDTO);
        Task Delete(int id);
    }
}
