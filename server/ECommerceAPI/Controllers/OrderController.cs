using BusinessObject.DTOs.Order;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository repository;

        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                return StatusCode(200, await repository.GetOrders());
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderCreateUpdateDTO orderDTO)
        {
            try
            {
                return StatusCode(200, await repository.SaveOrder(orderDTO));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOrderById(int id)
        {
            try
            {
                return StatusCode(200, await repository.FindOrderById(id));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatus(int id, int status)
        {
            try
            {
                return StatusCode(200, await repository.ChangeStatus(id, status));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("MyOrder/{id}")]
        public async Task<IActionResult> GetMyOrder(int id)
        {
            try
            {
                return StatusCode(200, await repository.GetMyOrder(id));
            }
            catch (ApplicationException ae)
            {
                return StatusCode(400, ae.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
