using System;


namespace Product.Domain
{
    public class ProductDetail
    {
        public Guid? Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public virtual PriceDetail PriceDetail { get; set; }
    }
}
