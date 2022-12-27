using Microsoft.AspNetCore.Mvc;
using MP.ApiDotnet6.Application.DTOs;
using MP.ApiDotnet6.Application.Services.Interface;

namespace MP.ApiDotnet6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProductAsync")]
        public async Task<ActionResult> CreateProductAsync(ProductDTO productDTO)
        {
            try
            {
                var result = await _productService.CreateAsync(productDTO);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _productService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.RemoveAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

        [HttpPost("EditProductAsync")]
        public async Task<ActionResult> EditProductAsync(ProductDTO productDTO)
        {
            try
            {
                var result = await _productService.UpdateAsync(productDTO);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
