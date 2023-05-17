using BusinessObject.Migrations;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        public static async Task<List<Order>> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    orders = await db.Orders.Include(x => x.Customer).Include(x => x.Employee).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public static async Task<bool> SaveOrder(Order order)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                    await db.AddAsync(order);
                    return await db.SaveChangesAsync() > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public static async Task<Order> FindOrderById(int id)
        {
            Order order = new Order();
            try
            {
                using (var db = new ECommerceContext())
                {
                    order = await db.Orders.FirstOrDefaultAsync(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
        }

        public static async Task<bool> ChangeStatus(int id, int status)
        {
            try
            {
                using (var db = new ECommerceContext())
                {
                    var order = await FindOrderById(id);
                    order.Status = status;
                    return await db.SaveChangesAsync() > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<List<Order>> GetMyOrder(int CustomerId)
        {
            var orders = new List<Order>();
            try
            {
                using (var db = new ECommerceContext())
                {
                    orders = await db.Orders.Include(x => x.Customer).Include(x => x.Employee).Where(x => x.CustomerId == CustomerId).ToListAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }
    }
}
