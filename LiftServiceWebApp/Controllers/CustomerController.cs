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
    public class CustomerController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
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

            _dbContext.Failures.Add(model);
            _dbContext.SaveChanges();
            return View();
        }

        //[HttpGet]
        //public IActionResult UpdateFailure(Guid id)
        //{
        //    var failure = _dbContext.Failures.Find(id);
        //    if (failure == null)
        //    {

        //    }

        //    return View(failure);
        //}

        //[HttpPost]
        //public IActionResult UpdateFailure(string lat, string lng, Failure model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    Failure failure = _dbContext.Failures.Find(model.Id);
        //    failure.FailureName = model.FailureName;
        //    failure.FailureDescription = model.FailureDescription;
        //    failure.AddressDetail = model.AddressDetail;
        //    failure.UpdatedDate = DateTime.Now;
        //    failure.Latitude = lat;
        //    failure.Longitude = lng;

        //    _dbContext.SaveChanges();
        //    return RedirectToAction("GetFailures");
        //}
        //public IActionResult DeleteIssue(Guid id)
        //{
        //    var issue = _dbContext.Failures.Find(id);
        //    if (issue == null)
        //    {

        //    }

        //    _dbContext.Remove(issue);
        //    _dbContext.SaveChanges();

        //    return RedirectToAction("GetIssues");
        //}
    }
}
