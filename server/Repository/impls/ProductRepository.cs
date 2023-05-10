using AutoMapper;
using BusinessObject.DTOs.Product;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class ProductRepository : IProductRepository
    {

        private readonly IMapper _mapper;
        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<string> Create(ProductCreateUpdateDTO productDTO)
        {
            var _product = _mapper.Map<Product>(productDTO);
            return ProductDAO.Create(_product);
        }

        public async Task Delete(int id)
        {
            await ProductDAO.DeleteProduct(id);
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
           return _mapper.Map<ProductDTO>(await ProductDAO.GetProduct(id));
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
           return _mapper.Map<List<ProductDTO>>(await ProductDAO.GetProducts());
        }


        public Task<string> Update(ProductCreateUpdateDTO productDTO)
        {
            var _product = _mapper.Map<Product>(productDTO);
            return ProductDAO.Update(_product);
        }
    }
}
