using LiftServiceWebApp.Models.Abstracts;
using LiftServiceWebApp.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftServiceWebApp.Models.Entities
{
    public class Address : BaseEntity<Guid>
    {
        public string ApartmentBuilding { get; set; }
        public string ApartmentNo { get; set; }
        public string AddressString { get; set; }
        public AddressTypes AddressType { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }
    }

    public enum AddressTypes
    {
        Fatura,
        Teslimat
    }
}
