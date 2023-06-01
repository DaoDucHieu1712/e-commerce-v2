    using AutoMapper;
using BusinessObject.DTOs.Product;
using BusinessObject.Models;
using DataAccess;
using DataAccess.Utils;
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

        public async Task<ProductFilterAndPagingDTO> FilterProduct(int? pageIndex, string? name, decimal? toPrice, decimal? fromPrice, int? categoryId, string? sortType)
        {
            int pageSize = 12;
            List<ProductDTO> _products = _mapper.Map<List<ProductDTO>>(await ProductDAO.FilterProduct(name, toPrice, fromPrice, categoryId, sortType));
            List<ProductDTO> products =  await PaginatedList<ProductDTO>.CreateAsync(_products, pageIndex ?? 1, pageSize);
            var TotalPages = (int)Math.Ceiling(_products.Count / (double)pageSize);
            ProductFilterAndPagingDTO p = new ProductFilterAndPagingDTO() {
                Products= products,
                PageIndex = pageIndex ?? 1,
                Total = TotalPages,
            };
            return p;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
           return _mapper.Map<ProductDTO>(await ProductDAO.GetProduct(id));
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
           return _mapper.Map<List<ProductDTO>>(await ProductDAO.GetProducts());
        }

        public async Task<List<ProductDTO>> GetProductsByCategory(int id)
        {
            return _mapper.Map<List<ProductDTO>>(await ProductDAO.GetProductsByCategory(id));   
        }

        public async Task<List<ProductDTO>> GetProductsDelete()
        {
            return _mapper.Map<List<ProductDTO>>(await ProductDAO.GetProductsDelete());
        }

        public async Task<bool> Restock(int id)
        {
            return await ProductDAO.Restock(id);
        }

        public async Task<List<ProductDTO>> SearchProduct(string? name, decimal? toPrice, decimal? fromPrice, int? categoryId, string? sortType)
        {
            return _mapper.Map<List<ProductDTO>>(await ProductDAO.FilterProduct(name, toPrice, fromPrice, categoryId, sortType));
        }

        public Task<string> Update(ProductCreateUpdateDTO productDTO)
        {
            var _product = _mapper.Map<Product>(productDTO);
            return ProductDAO.Update(_product);
        }

    }
}
