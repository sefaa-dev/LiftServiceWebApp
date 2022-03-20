using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftServiceWebApp.Models.Entities
{
    public class BasketProduct
    {
        // Basket Id
        public Guid BasketId { get; set; }
        [ForeignKey(nameof(BasketId))]
        public virtual Basket Basket { get; set; }


        // Product Id
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }


        // Product -> Quantity and Price
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
    }
}
