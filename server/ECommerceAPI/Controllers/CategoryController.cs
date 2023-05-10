using BusinessObject.DTOs.Category;
using BusinessObject.DTOs.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository repository;

        public CategoryController(ICategoryRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return StatusCode(200, await repository.GetCategories());
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
        public async Task<IActionResult> Create(CategoryCreateUpdateDTO categoryDTO)
        {
            try
            {
                return StatusCode(200, await repository.Create(categoryDTO));
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
