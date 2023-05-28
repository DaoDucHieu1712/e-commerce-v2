using BusinessObject.DTOs.Product;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<List<ProductDTO>> GetProductsDelete();
        Task<List<ProductDTO>> GetProductsByCategory(int id);
        Task<ProductDTO> GetProduct(int id);
        Task<bool> Restock(int id);
        Task<string> Create(ProductCreateUpdateDTO productDTO);
        Task<string> Update(ProductCreateUpdateDTO productDTO);
        Task Delete (int id);
        Task<List<ProductDTO>> FilterProduct(int? pageIndex, string? name, decimal? toPrice, decimal? fromPrice, int? categoryId, string? sortType);
    }
}
