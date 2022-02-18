using LiftServiceWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class IssueAssignViewModel
    {
        public DateTime CreatedDate { get; set; }
        public FailureStates FailureState { get; set; }
        public string TechnicianName { get; set; }
        public string FailureName { get; set; }
        public string FailureId { get; set; }
    }
}