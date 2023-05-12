using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static async Task<List<Category>> GetCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    categories = await db.Categories.ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return categories;
        }

        public static async Task<Category> GetCategory(int id)
        {
            Category category = new Category();
            try
            {
                using (var db = new ECommerceContext())
                {
                    category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public static async Task<string> Create(Category category)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                   await db.Categories.AddAsync(category);
                   await db.SaveChangesAsync();
                   return "Create new category successful !";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<string> Update(Category category)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                    db.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await db.SaveChangesAsync();
                    return "Update category successful !!!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task Delete(int id)
        {
            Category _category = new Category();
            try
            {
                using (var db = new ECommerceContext())
                {
                    _category = await db.Categories.FirstOrDefaultAsync(x => x.Id == id);
                    db.Categories.Remove(_category);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
