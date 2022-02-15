using DevExtreme.AspNet.Data;
using LiftServiceWebApp.Areas.ViewModels;
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
        private readonly MyContext _dbContext;
        public UserApiController(UserManager<ApplicationUser> userManager, MyContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
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
            //Kullanıcı 
            var data = _userManager.Users.FirstOrDefault(x => x.Id == key);

            if (data == null)
                return StatusCode(StatusCodes.Status409Conflict, new JsonResponseViewModel()
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı Bulunamadı"
                });

            var userRoleUpdateModel = new UserRoleUpdateViewModel();
            var userOldRole = _dbContext.UserRoles.Where(x => x.UserId == data.Id).Select(x => x.RoleId).Single();

            string oldRoleName = _dbContext.Roles.SingleOrDefault(r => r.Id == userOldRole).Name;

            JsonConvert.PopulateObject(values, userRoleUpdateModel);
            string newRoleName = _dbContext.Roles.SingleOrDefault(r => r.Id == userRoleUpdateModel.RoleId).Name;

            if (!string.IsNullOrEmpty(userRoleUpdateModel.RoleId))
            {
                await _userManager.RemoveFromRoleAsync(data, oldRoleName);
                await _userManager.AddToRoleAsync(data, newRoleName);

            }

            JsonConvert.PopulateObject(values, data); //değişiklik varsa değişiklik olanları günceller
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

        [HttpGet]
        public async Task<object> RolesLookup(string userId, DataSourceLoadOptions loadOptions)
        {
            string role = string.Empty;
            if(!string.IsNullOrEmpty(userId))
            {
                var user = await _userManager.FindByIdAsync(userId);
                role = _userManager.GetRolesAsync(user).Result.First();
            }
            var data = _dbContext.Roles
                .Select(x => new
                {
                    Value = x.Id,
                    Text = $"{x.Name}",
                    Selected = x.Name == role ? true : false
                });

            return Ok(DataSourceLoader.Load(data, loadOptions));
        }

    } 
}