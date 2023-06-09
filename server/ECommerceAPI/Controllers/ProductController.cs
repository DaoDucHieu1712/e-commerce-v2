﻿using BusinessObject.DTOs.Product;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return StatusCode(200, await repository.GetProducts());
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


        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            try
            {
                return StatusCode(200, await repository.GetProductsByCategory(id));
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

        [HttpGet("Trash")]
        public async Task<IActionResult> GetProductsDelete()
        {
            try
            {
                return StatusCode(200, await repository.GetProductsDelete());
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
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                return StatusCode(200, await repository.GetProduct(id));
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
        public async Task<IActionResult> Create(ProductCreateUpdateDTO productDTO)
        {
            try
            {
                return StatusCode(200, await repository.Create(productDTO));
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
        public async Task<IActionResult> Update(int id, ProductCreateUpdateDTO request)
        {
            try
            {
                request.Id = id;
                return StatusCode(200, await repository.Update(request));
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
                return StatusCode(200, "Delete Product successful !");
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

        [HttpPut("ReStock/{id}")]
        public async Task<IActionResult> ReStock(int id)
        {
            try
            {
                return StatusCode(200, await repository.Restock(id));
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


        [HttpPost("Search")]
        public async Task<IActionResult> Search([FromBody] ProductFilterDTO productFilter)
        {
            try
            {
                return StatusCode(200, await repository.SearchProduct(productFilter.Name, productFilter.ToPrice, productFilter.FromPrice, productFilter.CategoryId, productFilter.SortType));
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

        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(int? pageIndex, string? name, decimal? toPrice, decimal? fromPrice, int? categoryId, string? sortType)
        {
            try
            {
                return StatusCode(200, await repository.FilterProduct(pageIndex, name, toPrice, fromPrice, categoryId,sortType));
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
