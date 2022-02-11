using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Entities
{
    public class SubscriptionType : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Month { get; set; }
        public decimal Price { get; set; }
    }
}