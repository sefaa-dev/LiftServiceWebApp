using LiftServiceWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class AssignedFailureViewModel
    {
        public string FailureName { get; set; }
        public string FailureDescription { get; set; }
        public FailureStates FailureState { get; set; }
        public string TechnicianName { get; set; }
        public string AddressDetail { get; set; }
        public string Latitude { get; set; }//Enlem
        public string Longitude { get; set; }//Boylam
        public DateTime CreatedDate { get; set; }
    }
}