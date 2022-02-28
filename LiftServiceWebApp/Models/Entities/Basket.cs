using LiftServiceWebApp.Models.Abstracts;
using LiftServiceWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        public string OrderStatue { get; set; }
        public string Price { get; set; }

        public enum OrderStatus
        {
            Eklendi,
            IptalEdildi,
            OdemeBekliyor,
            Odendi
        }
    }
}
