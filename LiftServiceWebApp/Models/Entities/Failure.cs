using LiftServiceWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Models.Entities
{
    public class Failure
    {
        public string FailureName { get; set; }
        public string FailureDescription { get; set; }
        public string FailureStatus { get; set; }
        public float Latitude { get; set; }//Enlem
        public float Longitude { get; set; }//Boylam
        public string AddressDetail { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
    public enum FailureStatus
    {
        Alındı,
        Adreste,
        OdemeBekleniyor,
        Sonuclandi
    }
}