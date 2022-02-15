using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class CustomerManageController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerManageController(MyContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
       
        [HttpGet]
        public async Task<IActionResult> GetFailure()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var failures = _dbContext.Failures.Where(x => x.UserId.ToString() == user.Id).ToList();
            return View(failures);
        }

        [HttpGet]
        public IActionResult CreateFailuree()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateFailuree(string lat, string lng, Failure model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null)
            {

            }

            var failure = new Failure()
            {
                FailureName = model.FailureName,
                FailureDescription = model.FailureDescription,
                AddressDetail = model.AddressDetail,
                UserId = user.Id,
                FailureStatus = FailureStates.Alındı.ToString(),
                CreatedDate = DateTime.Now,
                CreatedUser = user.Id,
                Latitude = lat,
                Longitude = lng
            };

            _dbContext.Failures.Add(failure);
            _dbContext.SaveChanges();


            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateFailure(Guid id)
        {
            var failure = _dbContext.Failures.Find(id);
            if (failure == null)
            {

            }

            return View(failure);
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
            return RedirectToAction("GetFailures");
        }


        public IActionResult DeleteIssue(Guid id)
        {
            var issue = _dbContext.Failures.Find(id);
            if (issue == null)
            {

            }

            _dbContext.Remove(issue);
            _dbContext.SaveChanges();

            return RedirectToAction("GetIssues");
        }
    }
}
