using BusinessObject.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetOrders();
        Task<bool> SaveOrder(OrderCreateUpdateDTO orderDTO);
        Task<OrderDTO> FindOrderById(int id);
        Task<bool> ChangeStatus(int id, int status);
        Task<List<OrderDTO>> GetMyOrder(int CustomerId);
    }
}
