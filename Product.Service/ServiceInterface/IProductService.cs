using Product.Service.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.ServiceInterface
{
    public interface IProductService
    {
        Task<List<ProductDetailDto>> GetProductDetailsAsync();
        Task<ProductDetailDto> GetProductDetailByIdAsync(Guid productId);
        Task<Guid> CreateProductDetailAsync(ProductDetailDto productDetailDto);
        Task<Guid> UpdateProductDetailAsync(ProductDetailDto productDetailDto);
        Task DeleteProductDetailAsync(Guid productId);
    }
}
