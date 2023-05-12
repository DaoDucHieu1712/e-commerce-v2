using AutoMapper;
using BusinessObject.DTOs.Category;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> Create(CategoryCreateUpdateDTO categoryDTO)
        {
            var _category = _mapper.Map<Category>(categoryDTO);
            return await CategoryDAO.Create(_category);
        }

        public async Task Delete(int id)
        {
            await CategoryDAO.Delete(id);
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            return _mapper.Map<List<CategoryDTO>>(await CategoryDAO.GetCategories());
        }

        public async Task<CategoryDTO> GetCategory(int id)
        {
            return _mapper.Map<CategoryDTO>(await CategoryDAO.GetCategory(id));
        }

        public async Task<string> Update(CategoryUpdateDTO categoryDTO)
        {
            var _category = _mapper.Map<Category>(categoryDTO);
            return await CategoryDAO.Update(_category);
        }
    }
}
