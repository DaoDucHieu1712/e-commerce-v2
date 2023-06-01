using BusinessObject.Models;
using DataAccess.Utils;
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

        public static async Task<List<Product>> GetProductsDelete()
        {
            var products = new List<Product>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    products = await db.Products.Where(x => x.IsDelete == true).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public static async Task<List<Product>> GetProducts()
        {
            var products = new List<Product>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    products = await db.Products.Include(x => x.Category).Where(x => x.IsDelete == false).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return products;
        }

        public static async Task<List<Product>> GetProductsByCategory(int id)
        {
            var products = new List<Product>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    products = await db.Products.Where(x => x.IsDelete == false && x.CategoryId == id).ToListAsync();
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
                using (var db = new ECommerceContext())
                {
                    var product = await GetProduct(id);
                    product.IsDelete = true;
                    db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static async Task<bool> Restock(int id)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                    var product = await GetProduct(id);
                    product.IsDelete = false;
                    db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return await db.SaveChangesAsync() > 0;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public static async Task<List<Product>> FilterProduct(string? name, decimal? toPrice, decimal? fromPrice, int? categoryId, string? sortType)
        {
            List<Product> products = new List<Product>();
             try
            {
                using (var db = new ECommerceContext())
                {
                    products = await GetProducts();

                    if (sortType != null)
                    {
                        switch (sortType)
                        {
                            case "name-asc":
                                products = products.OrderBy(x => x.Name).ToList();
                                break;
                            case "name-desc":
                                products = products.OrderByDescending(x => x.Name).ToList();
                                break;
                            case "price-asc":
                                products = products.OrderBy(x => x.Price).ToList();
                                break;
                            case "price-desc":
                                products = products.OrderByDescending(x => x.Price).ToList();
                                break;
                            default:
                                products = products.OrderBy(x => x.Name).ToList();
                                break;
                        }
                    }

                    if (name!=null)
                    {
                        products = products.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
                    }

                    if(toPrice != null)
                    {
                        products = products.Where(x => x.Price >= toPrice).ToList();
                    }

                    if (fromPrice != null)
                    {
                        products = products.Where(x => x.Price <= fromPrice).ToList();
                    }

                    if(categoryId != null)
                    {
                        products = products.Where(x => x.CategoryId == categoryId).ToList();
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
    }
}
