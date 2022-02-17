﻿using LiftServiceWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class IssueAssignViewModel
    {
        public DateTime CreatedDate { get; set; }
        public FailureStates FailureState { get; set; } = FailureStates.Alındı;
        public string TechnicianName { get; set; }
        public string FailureName { get; set; }
    }
}