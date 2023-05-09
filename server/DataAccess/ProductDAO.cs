using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static async Task<List<Product>> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    products = await db.Products.Where(x => x.IsDelete == false).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return products;
        }

        public static async Task<Product> GetProduct(int id)
        {
            Product product = new Product();
            try
            {
                using (var db = new ECommerceContext())
                {
                    product = await db.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public static async Task<string> Create(Product product)
        {
            try
            {
                using(var db = new ECommerceContext())
                {
                    await db.Products.AddAsync(product);
                    await db.SaveChangesAsync();
                    return "Create successful !!!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<string> Update(Product product)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                    db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                    return "Update successful !!!";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static async Task DeleteProduct(int id)
        {
            try
            {
                Product product = new Product();
                using (var db = new ECommerceContext())
                {
                    product = await db.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == id);
                    product.IsDelete = true;
                    db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
