using AutoMapper;
using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models;
using LiftServiceWebApp.Models.Entities;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.Services;
using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;


        public CustomerController(MyContext dbContext, UserManager<ApplicationUser> userManager, IEmailSender emailSender, IMapper mapper)
        {
            _emailSender = emailSender;
            _dbContext = dbContext;
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
        public IActionResult Failures()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFailure(string lat, string lng, Failure model)
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            if (user == null)
            {
                ViewBag.Message = "Lütfen giriş yapınız.";
                return RedirectToAction("Login", "Account");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Lütfen tüm alanları doldurunuz.";                
                return View(model);
            }
            else
            {           

                model.UserId = user.Id;
                model.CreatedUser = user.Id;
                model.CreatedDate = DateTime.Now;
                model.Latitude = lat;
                model.Longitude = lng;

                _dbContext.Failures.Add(model);
                _dbContext.SaveChanges();
                
                //Talebiniz alındı Email mesajı gönderme
                var callbackUrl = Url.Action("Failures", "Customer", new { userId = user.Id },
                    protocol: Request.Scheme);

                var emailMessage = new EmailMessage()
                {
                    Contacts = new string[] { user.Email },
                    Body =
                        $"Arıza/bakım servis talebiniz alınmıştır. Servis taleplerinizi görüntülemek için <a href='{callbackUrl}'>buraya tıklayınız. </a>.",
                    Subject = "Talebiniz Alındı."
                };

                await _emailSender.SendAsync(emailMessage);
            }
            TempData["Message"] = "Arıza/bakım servis talebiniz olmuştur.";
            return RedirectToAction("Failures", "Customer");
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
            _dbContext.Remove(failure);
            _dbContext.SaveChanges();

            return RedirectToAction("Failures");
        }
    }
}
