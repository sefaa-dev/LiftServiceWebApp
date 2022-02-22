using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class OperatorController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public OperatorController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        // Atanmayan Arızaları Görüntüleme
        public async Task<IActionResult> FailureAssign()
        {
            // Arızalar
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _dbContext.Failures.Where(x => x.TechnicianId == null).ToList();

            // Teknisyenler
            var technicians = await _userManager.GetUsersInRoleAsync("Technician");
            List<TechnicianAssignViewModel> technicianList = new List<TechnicianAssignViewModel>();
            foreach (var item in technicians)
            {
                TechnicianAssignViewModel technicianAssignViewModel = new TechnicianAssignViewModel
                {
                    TechnicianId = item.Id,
                    TechnicianName = $"{item.Name} {item.Surname}"
                };
                technicianList.Add(technicianAssignViewModel);
            }
            ViewBag.Technicians = technicianList;
            return View(failures);
        }

        // Teknisyen Atama ve Atanan Arızaları Görüntüleme
        [HttpPost]
        public async Task<IActionResult> FailureAssign(string technicianId, string failureId)
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failure = _dbContext.Failures.Where(x => x.Id.ToString() == failureId).SingleOrDefault();
            failure.TechnicianId = technicianId;
            failure.FailureState = FailureStates.TeknisyenAtandı;
            failure.UpdatedUser = user.UserName;
            failure.UpdatedDate = DateTime.Now;
            _dbContext.Update(failure);
            _dbContext.SaveChanges();
            return RedirectToAction("GetFailure", "Operator");
        }

        public async Task<IActionResult> GetFailure()
        {
            var failures = _dbContext.Failures.ToList();
            List<AssignedFailureViewModel> assignedFailureViewModels = new List<AssignedFailureViewModel>();
            foreach (var item in failures)
            {
                var technician = await _userManager.FindByIdAsync(item.TechnicianId);
                string technicianName;
                if (technician == null)
                    technicianName = null;
                else
                    technicianName = $"{ technician.Name } {technician.Surname}";
                assignedFailureViewModels.Add(new AssignedFailureViewModel
                {
                    FailureName = item.FailureName,
                    FailureDescription = item.FailureDescription,
                    AddressDetail = item.AddressDetail,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    CreatedDate = item.CreatedDate,
                    FailureState = item.FailureState,
                    TechnicianName = technicianName
                });
            }
            return View(assignedFailureViewModels);
        }
    }
}