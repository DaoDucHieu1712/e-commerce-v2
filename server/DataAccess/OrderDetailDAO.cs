using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {

        public static async Task<bool> SaveOrderDetail(OrderDetail od)
        {
			try
			{
				using(var db = new ECommerceContext())
				{
					await db.OrderDetails.AddAsync(od);
					return await db.SaveChangesAsync() > 0;
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
        }

		public static async Task<List<OrderDetail>> GetOrderDetails(int OrderId)
		{
			var orderdetails = new List<OrderDetail>();
			try
			{
                using (var db = new ECommerceContext())
                {
					orderdetails = await db.OrderDetails.Where(x => x.OrderId == OrderId).ToListAsync();
                }
            }
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
			return orderdetails;
		} 

    }
}
