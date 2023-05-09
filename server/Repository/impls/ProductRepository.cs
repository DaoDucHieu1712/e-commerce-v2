using BusinessObject.DTOs.Product;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class ProductRepository : IProductRepository
    {
        public Task<string> Create(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
