using LiftServiceWebApp.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace LiftServiceWebApp.Models.Entities
{
    public class Product : BaseEntity<Guid>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Categories category { get; set; }
        public enum Categories
        {
            Iscilik,
            Malzeme
        }
    }
}
