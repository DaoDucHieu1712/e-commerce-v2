using AutoMapper;
using BusinessObject.DTOs.Order;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.impls
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMapper _mapper;
        public OrderRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<bool> ChangeStatus(int id, int status)
        {
           return await OrderDAO.ChangeStatus(id, status);
        }

        public async Task<OrderDTO> FindOrderById(int id)
        {
           return _mapper.Map<OrderDTO>(await OrderDAO.FindOrderById(id));
        }

        public async Task<List<OrderDTO>> GetMyOrder(int CustomerId)
        {
            return _mapper.Map<List<OrderDTO>>(await OrderDAO.GetMyOrder(CustomerId));
        }

        public async Task<List<OrderDTO>> GetOrders()
        {
            return _mapper.Map<List<OrderDTO>>(await OrderDAO.GetOrders());
        }

        public async Task<bool> SaveOrder(OrderCreateUpdateDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            return await OrderDAO.SaveOrder(order);
        }
    }
}
