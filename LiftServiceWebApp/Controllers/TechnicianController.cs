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
        private readonly ProductRepo _productRepo;
        public TechnicianController(
            FailureRepo failureRepo,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ProductRepo productRepo)
        {
            _failureRepo = failureRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _productRepo = productRepo;
        }

        public async Task<IActionResult> GetFailures()
        {
            var technician = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _failureRepo.GetByTechnicianId(technician.Id).ToList();

            return View(failures);
        }      
        [HttpPost]
        public async Task<IActionResult> GetFailures(string failureId)
        {
            var failure = _failureRepo.GetById(Guid.Parse(failureId));
     
            failure.FailureState = FailureStates.KabulEdildi;
            _failureRepo.Update(failure);

            var technician = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _failureRepo.GetByTechnicianId(technician.Id).ToList();
            return View(failures);
        }

        [HttpPost]
        public IActionResult Payment(PaymentIdViewModel paymentIdViewModel)
        {
            var products = _productRepo.Get().ToList();
            return View(products);
        }

        
    }
}
