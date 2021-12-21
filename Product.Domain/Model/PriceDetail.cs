using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Product.Domain
{
    public class PriceDetail
    {
        public Guid? Id { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public ProductDetail Product { get; set; }
        public bool IsActive { get; set; }
    }
}
