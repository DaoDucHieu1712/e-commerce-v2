using BusinessObject.DTOs.OrderDetailDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IOrderDetailRepository repository;

        public OrderDetailController(IOrderDetailRepository repo)
        {
            repository = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailByOrder(int id)
        {
            try
            {
                return StatusCode(200, await repository.GetOrderDetails(id));
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
        public async Task<IActionResult> SaveOrderDetail(OrderDetailDTO orderDetailDTO)
        {
            try
            {
                return StatusCode(200, await repository.SaveOrderDetail(orderDetailDTO));
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
