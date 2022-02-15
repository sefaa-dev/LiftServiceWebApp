using LiftServiceWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Models.Entities
{
    public class Failure:BaseEntity
    {
        public string FailureName { get; set; }
        public string FailureDescription { get; set; }
        public string FailureStatus { get; set; }
        public string Latitude { get; set; }//Enlem
        public string Longitude { get; set; }//Boylam
        public string AddressDetail { get; set; }
        public FailureStates FailureState { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
    public enum FailureStates
    {
        Alındı,
        Adreste,
        OdemeBekleniyor,
        Sonuclandi
    }
}