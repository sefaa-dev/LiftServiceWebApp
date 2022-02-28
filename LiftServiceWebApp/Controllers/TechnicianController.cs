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
    public class TechnicianController : Controller
    {
        private readonly FailureRepo _failureRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public TechnicianController(
            FailureRepo failureRepo,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _failureRepo = failureRepo;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> GetFailures()
        {
            var technician = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _failureRepo.GetByTechnicianId(technician.Id).ToList();

            return View(failures);
        }      
        [HttpPost]
        public async Task<IActionResult> GetFailures(Guid failureId)
        {
            var failure = _failureRepo.GetById(failureId);
     
            failure.FailureState = FailureStates.KabulEdildi;
            _failureRepo.Update(failure);


         //YARIM KALDI//

            var technician = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _dbContext.Failures.Where(x => x.TechnicianId == technician.Id && (x.FailureState == FailureStates.Yonlendirildi || x.FailureState == FailureStates.KabulEdildi)).ToList();
            return View(failures);
        }
        [HttpPost]
        public IActionResult Payment(string userId)
        {
            
            if (true)
            {

            }

            return View();
        }

        
    }
}
