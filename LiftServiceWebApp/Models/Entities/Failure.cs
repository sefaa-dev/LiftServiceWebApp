using LiftServiceWebApp.Models.Abstracts;
using LiftServiceWebApp.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftServiceWebApp.Models.Entities
{
    public class Failure:BaseEntity<Guid>
    {
        public string FailureName { get; set; }
        public string FailureDescription { get; set; }
        public string Latitude { get; set; }//Enlem
        public string Longitude { get; set; }//Boylam
        public string AddressDetail { get; set; }
        public FailureStates FailureState { get; set; }
        public string TechnicianId { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    public enum FailureStates
    {
        Alındı,
        Yonlendirildi,
        KabulEdildi,
        OdemeBekleniyor,
        Sonuclandi
    }
}