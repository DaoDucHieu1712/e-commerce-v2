using AutoMapper;
using BusinessObject.DTOs.Order;
using BusinessObject.DTOs.OrderDetailDTO;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IMapper _mapper;
        public OrderDetailRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<List<OrderDetailDTO>> GetOrderDetails(int OrderId)
        {
            return _mapper.Map<List<OrderDetailDTO>>(await OrderDetailDAO.GetOrderDetails(OrderId));
        }

        public async Task<bool> SaveOrderDetail(OrderDetailDTO orderDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDTO);
            return await OrderDetailDAO.SaveOrderDetail(orderDetail);
        }
    }
}
