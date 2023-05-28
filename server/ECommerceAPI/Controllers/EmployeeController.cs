using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                return StatusCode(200, await repository.GetEmployees());
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
