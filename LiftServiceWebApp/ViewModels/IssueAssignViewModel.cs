using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.ViewModels
{
    public class IssueAssignViewModel
    {
        public string CreatedDate { get; set; }
        public IssueStates IssueState { get; set; }
        public string TechnicianName { get; set; }
        public enum IssueStates
        {
            Beklemede,
            Atandi,
            Islemde,
            Tamamlandi
        }
    }
}
