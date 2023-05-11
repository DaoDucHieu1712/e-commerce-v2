using BusinessObject.DTOs.Category;
using BusinessObject.DTOs.Product;
using DataAccess;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            try
            {
                return StatusCode(200, await repository.GetCategory(id));
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateDTO categoryDTO)
        {
            try
            {
                categoryDTO.Id = id;
                return StatusCode(200, await repository.Update(categoryDTO));
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await repository.Delete(id);
                return StatusCode(200, "Delete category successful !!!");
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
