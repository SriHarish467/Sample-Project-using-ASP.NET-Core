using AutoMapper;
using Product.Domain;
using Product.Repository.RepositoryInterface;
using Product.Service.Dto;
using Product.Service.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Service.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _repository,IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        //Method to Get List of ProductDetails
        public async Task<List<ProductDetailDto>> GetProductDetailsAsync()
        {
            var product = await repository.GetProductDetailsAsync();
            return mapper.Map<List<ProductDetailDto>>(product);
        }

        //Method to Get a ProductDetail using ProductId
        public async Task<ProductDetailDto> GetProductDetailByIdAsync(Guid productId)
        {
            var product = await repository.GetProductDetailByIdAsync(productId);
            return mapper.Map<ProductDetailDto>(product);
        }

        //Method to Create a ProductDetail
        public async Task<Guid> CreateProductDetailAsync(ProductDetailDto productDetailDto)
        {
            var productDetail = mapper.Map<ProductDetail>(productDetailDto);
            await repository.CreateProductDetailAsync(productDetail);
            return new Guid();
        }

        //Method to Update ProductDetail
        public async Task<Guid> UpdateProductDetailAsync(ProductDetailDto productDetailDto)
        {
            var productDetail = mapper.Map<ProductDetail>(productDetailDto);
            await repository.UpdateProductDetailAsync(productDetail);
            return new Guid();
        }

        //Method to Delete ProductDetail from the Table
        public async Task DeleteProductDetailAsync(Guid productId)
        {
            await repository.DeleteProductDetailAsync(productId);
        }
    }
}
