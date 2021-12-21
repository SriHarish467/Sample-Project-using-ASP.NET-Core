using Product.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Product.Repository.RepositoryInterface
{
    public interface IProductRepository
    {
        Task<List<ProductDetail>> GetProductDetailsAsync();
        Task<ProductDetail> GetProductDetailByIdAsync(Guid productId);
        Task CreateProductDetailAsync(ProductDetail productDetail);
        Task UpdateProductDetailAsync(ProductDetail productDetail);
        Task DeleteProductDetailAsync(Guid ProductId);

    }
}
