using System;
using System.Collections.Generic;
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
    }

    public enum AddressTypes
    {
        Fatura,
        Teslimat
    }
}
