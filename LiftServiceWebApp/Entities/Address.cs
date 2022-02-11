using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Entities
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Line { get; set; }
        public AddressTypes AddressType { get; set; }
    }

    public enum AddressTypes
    {
        Fatura,
        Teslimat
    }
}
