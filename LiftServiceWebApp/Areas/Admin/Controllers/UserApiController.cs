using DevExtreme.AspNet.Data;
using LiftServiceWebApp.Data;
using LiftServiceWebApp.Extensions;
using LiftServiceWebApp.Models.Identity;
using LiftServiceWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class UserApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetUsers(DataSourceLoadOptions loadOptions)
        {
            var data = _userManager.Users;
            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsers(string key, string values)
        {
            var data = _userManager.Users.FirstOrDefault(x => x.Id == key);
            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı bulunamadı"
                });

            JsonConvert.PopulateObject(values, data);
            if (!TryValidateModel(data))
                return BadRequest(ModelState.ToFullErrorString());

            var result = await _userManager.UpdateAsync(data);
            if (!result.Succeeded)
                return BadRequest(new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Güncellenemedi"
                });
            return Ok(new JsonResponseViewModel());
        }
    }
}