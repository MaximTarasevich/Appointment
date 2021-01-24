using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL;
using AppointmentService.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace AppointmentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private readonly DataManager _dm;

        public DataController(DataManager dm)
        {
            _dm = dm;
        }



        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] DataEntity model)
        {
            try
            {
                DataEntity entity = null;
                if (!ModelState.IsValid)
                    return null;
                var birthdate = new DateTime(model.BithdayDate.Year, model.BithdayDate.Month, model.BithdayDate.Day);
                    var user = await _dm.UserAccessor.GetUser(model.UserName, model.UserSurname, birthdate);
                if (user == null)
                    user = await _dm.UserAccessor.SaveUser(new UserEntity() { BithdayDate = birthdate, UserName = model.UserName, UserSurname = model.UserSurname });

                entity = new DataEntity();
                entity.Gender = model.Gender;
                entity.UserId = user.Id;
                entity.PhysicalActiveType = model.PhysicalActiveType;

                await _dm.DataAccessor.SaveAddress(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(new Exception());
            }
        }
        [Route("getusers")]
        public async Task<JsonResult> GetUsers()
        {
            var count = await _dm.UserAccessor.GetUsersCount();
            var list = await _dm.UserAccessor.GetUsers();



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    username = e.UserName,
                    usersurname = e.UserSurname,
                    birthdaydate = e.BithdayDate,
                }).ToList();

                var result = new
                {
                    Count = count,
                    Items = usersPagedData
                };
                return Json(result);
            }
            else
            {
                var result = new
                {
                    Count = 0,
                    Items = new List<UserEntity>()
                };
                return Json(result);
            }
        }


        [Route("getdata")]
        public async Task<JsonResult> GetData()
        {
            var count = await _dm.DataAccessor.GetDataCount();
            var list = await _dm.DataAccessor.GetData();



            if (list.Count > 0)
            {
                var usersPagedData = list.Select(e => new
                {
                    id = e.Id,
                    physicalactivetype = e.PhysicalActiveType,
                    gender = e.Gender,
                    userid = e.UserId,
                }).ToList();

                var result = new
                {
                    Count = count,
                    Items = usersPagedData
                };
                return Json(result);
            }
            else
            {
                var result = new
                {
                    Count = 0,
                    Items = new List<DataEntity>()
                };
                return Json(result);
            }
        }
    }
}