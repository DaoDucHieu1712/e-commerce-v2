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
    internal class CategoryRepository : ICategoryRepository
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDTO>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(CategoryCreateUpdateDTO categoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
