using Microsoft.EntityFrameworkCore;
using Product.Domain;
using Product.Domain.Context;
using Product.Repository.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Product.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext context;
        public ProductRepository(ProductDbContext _context)
        {
            context = _context;
        }

        //Method to Get List of ProductDetails
        public async Task<List<ProductDetail>> GetProductDetailsAsync()
        {
            List<ProductDetail> product = await context.ProductDetail.Where(x => x.IsActive == true).Include(p=>p.PriceDetail).Where(x => x.PriceDetail.IsActive == true).ToListAsync();
            return product;
        }

        //Method to Get a ProductDetail using ProductId
        public async Task<ProductDetail> GetProductDetailByIdAsync(Guid productId)
        {
            var productDetail = await context.ProductDetail.FindAsync(productId);
            if(productDetail != null)
            {
                productDetail.PriceDetail = await context.PriceDetail.FirstOrDefaultAsync(x => x.ProductId == productDetail.Id);
            }
            return productDetail;
        }

        //Method to Create a ProductDetail
        public async Task CreateProductDetailAsync(ProductDetail productDetail){
            productDetail.IsActive = true;
            productDetail.PriceDetail.IsActive = true;
            await context.ProductDetail.AddAsync(productDetail);
            await context.SaveChangesAsync();
        }

        //Method to Update ProductDetail
        public async Task UpdateProductDetailAsync(ProductDetail productDetail)
        {
            context.ProductDetail.Update(productDetail);
            await context.SaveChangesAsync();
        }

        //Method to Delete ProductDetail from the Table
        public async Task DeleteProductDetailAsync(Guid ProductId)
        {
            ProductDetail product = await context.ProductDetail.FindAsync(ProductId);
            if (product != null)
            {
                var priceDetail = context.PriceDetail.SingleOrDefault(x => x.ProductId == ProductId);
                context.PriceDetail.Remove(priceDetail);
                context.ProductDetail.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        //Method to disable the ProductDetail by updating the IsActive Status 
        public async Task SoftDeleteProductDetailAsync(ProductDetail productDetail)
        {
            productDetail.IsActive = false;
            productDetail.PriceDetail.IsActive = false;
            context.ProductDetail.Update(productDetail);
            await context.SaveChangesAsync();
        }
    }
}
