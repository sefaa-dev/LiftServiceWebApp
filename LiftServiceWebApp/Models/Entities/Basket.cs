using LiftServiceWebApp.Models.Abstracts;
using LiftServiceWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftServiceWebApp.Models.Entities
{
    public class Basket : BaseEntity<Guid>
    {
        public Guid FailureId { get; set; }

        [ForeignKey(nameof(FailureId))]
        public virtual Failure Failure { get; set; }

        public string CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual ApplicationUser CustomerUser { get; set; }

        public OrderStatus OrderStatue { get; set; }
        public decimal Price { get; set; }

        public ICollection<BasketProduct> BasketProducts { get; set; }

        public enum OrderStatus
        {
            Eklendi,
            IptalEdildi,
            OdemeBekliyor,
            Odendi
        }
    }
}
