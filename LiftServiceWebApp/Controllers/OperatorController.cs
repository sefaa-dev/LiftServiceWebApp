using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.Repository;
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
        private readonly FailureRepo _failureRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public OperatorController(FailureRepo failureRepo, 
            MyContext dbContext, 
            UserManager<ApplicationUser> userManager)
        {
            _failureRepo = failureRepo;
            _userManager = userManager;
        }
        // Atanmayan Arızaları Görüntüleme
        public async Task<IActionResult> FailureAssign()
        {
            // Arızalar
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _failureRepo.GetNotAssigned().ToList();

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

        // Teknisyen Atama 
        [HttpPost]
        public async Task<IActionResult> FailureAssign(string technicianId, string failureId)
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failure = _failureRepo.GetById(Guid.Parse(failureId));
            var technician = await _userManager.FindByIdAsync(technicianId);

            failure.TechnicianId = technicianId;
            failure.FailureState = FailureStates.Yonlendirildi;
            failure.UpdatedUser = user.UserName;
            failure.UpdatedDate = DateTime.Now;

            _failureRepo.Update(failure);
            return RedirectToAction("GetFailure", "Operator");
        }
        // Atanan Arızaları Görüntüleme
        public async Task<IActionResult> GetFailures()
        {
            var failures = _failureRepo.Get().ToList();
            List<AssignedFailureViewModel> assignedFailureViewModels = new List<AssignedFailureViewModel>();
            foreach (var item in failures)
            {
                var technician = await _userManager.FindByIdAsync(item.TechnicianId);
                string technicianName;
                if (technician == null)
                    technicianName = "Henüz teknisyen atanmadı";
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