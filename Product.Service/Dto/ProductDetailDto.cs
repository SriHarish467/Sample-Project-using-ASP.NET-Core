using System;



namespace Product.Service.Dto
{
    public class ProductDetailDto
    {
        public Guid? Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public PriceDetailDto PriceDetail { get; set; }
    }
}
