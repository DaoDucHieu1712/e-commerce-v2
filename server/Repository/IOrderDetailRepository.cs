using BusinessObject.DTOs.Order;
using BusinessObject.DTOs.OrderDetailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetailDTO>> GetOrderDetails(int OrderId);
        Task<bool> SaveOrderDetail(OrderDetailDTO orderDTO);
    }
}
