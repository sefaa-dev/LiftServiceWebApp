using DevExtreme.AspNet.Data;
using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FailureApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyContext _dbContext;
        public FailureApiController(UserManager<ApplicationUser> userManager, MyContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
       
        [HttpGet]
        public IActionResult GetFailures(DataSourceLoadOptions loadOptions)
        {
            var data = _dbContext.Failures.Where(x => x.UserId == HttpContext.GetUserId());
            //return View(failures);
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }
        [HttpPut]
        public IActionResult UpdateFailure()
        {
            return View();
        }
    }
}
