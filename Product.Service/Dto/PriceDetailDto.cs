using System;


namespace Product.Service.Dto
{
    public class PriceDetailDto
    {
        public Guid? Id { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public bool IsActive { get; set; }
    }
}
