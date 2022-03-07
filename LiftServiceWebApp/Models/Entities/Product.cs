using LiftServiceWebApp.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiftServiceWebApp.Models.Entities
{
    public class Product : BaseEntity<Guid>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Categories Category { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
        public enum Categories
        {
            Iscilik,
            Malzeme
        }
    }
}