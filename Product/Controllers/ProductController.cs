using Microsoft.AspNetCore.Mvc;
using Product.Service.Dto;
using Product.Service.ServiceInterface;
using System;
using System.Threading.Tasks;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService _service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductDetails()
        {
            var productDetails = await service.GetProductDetailsAsync();
            return Ok(productDetails);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(Guid id)
        {
            var productDetail = await service.GetProductDetailByIdAsync(id);
            return Ok(productDetail);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(ProductDetailDto productDetailDto)
        {
            var id = await service.CreateProductDetailAsync(productDetailDto);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(ProductDetailDto productDetailDto)
        {
            var id = await service.UpdateProductDetailAsync(productDetailDto);
            return Ok(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(Guid id)
        {
            await service.DeleteProductDetailAsync(id);
            return Ok();
        }
    }
}
