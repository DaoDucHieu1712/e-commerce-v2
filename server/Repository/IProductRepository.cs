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
        Task<Product> GetProduct(int id);
        Task<string> Create(ProductCreateUpdateDTO productDTO);
        Task<string> Update(ProductCreateUpdateDTO productDTO);
        Task Delete (int id);
    }
}
