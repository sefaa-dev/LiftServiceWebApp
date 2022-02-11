using LiftServiceWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Entities
{
    public class Address : BaseEntity
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
