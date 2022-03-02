﻿using AutoMapper;
using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.Repository;
using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly FailureRepo _failureRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public CustomerController(FailureRepo failureRepo,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _failureRepo = failureRepo;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateFailure()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFailure(string lat, string lng, Failure model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null)
            {

            }

            model.UserId = user.Id;
            model.CreatedUser = user.Id;
            model.CreatedDate = DateTime.Now;
            model.Latitude = lat;
            model.Longitude = lng;

            _failureRepo.Insert(model);
            return View();
        }
        [HttpGet]
        public IActionResult UpdateFailure(Guid id)
        {
            var failure = _dbContext.Failures.Find(id);
            if (failure == null)
            {

            }
            FailureViewModel VMFailure = _mapper.Map<FailureViewModel>(failure);
                return View(VMFailure);
        }

        [HttpPost]
        public IActionResult UpdateFailure(string lat, string lng, Failure model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Failure failure = _dbContext.Failures.Find(model.Id);
            failure.FailureName = model.FailureName;
            failure.FailureDescription = model.FailureDescription;
            failure.AddressDetail = model.AddressDetail;
            failure.UpdatedDate = DateTime.Now;
            failure.Latitude = lat;
            failure.Longitude = lng;

            _dbContext.SaveChanges();
            return RedirectToAction("Failures");
        }
        public IActionResult DeleteFailure(Guid id)
        {
            var failure = _dbContext.Failures.Find(id);
            if (failure == null)
            {

            }
            
        public async Task<IActionResult> GetFailures()
        {
            var failures = _failureRepo.Get().ToList();
            List<AssignedFailureViewModel> assignedFailureViewModels = new List<AssignedFailureViewModel>();
            foreach (var item in failures)
            {
                var technician = await _userManager.FindByIdAsync(item.TechnicianId);
                string technicianName;
                if (technician == null)
                    technicianName = null;
                else
                    technicianName = $"{ technician.Name.ToUpper() } { technician.Surname.ToUpper() }";
                assignedFailureViewModels.Add(new AssignedFailureViewModel
                {
                    FailureName = item.FailureName,
                    FailureDescription = item.FailureDescription,
                    FailureState = item.FailureState,
                    TechnicianName = technicianName
                });
            }
            return View(assignedFailureViewModels);
        }
    }
}
