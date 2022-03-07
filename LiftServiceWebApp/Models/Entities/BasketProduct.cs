using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftServiceWebApp.Models.Entities
{
    public class BasketProduct
    {
        public Guid BasketId { get; set; }
        [ForeignKey(nameof(BasketId))]
        public virtual Basket Basket { get; set; }

        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
    }
}
