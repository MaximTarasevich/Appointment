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

                var user = await _dm.UserAccessor.GetUser(model.UserName, model.UserSurname, model.BithdayDate);
                if (user == null)
                    user = await _dm.UserAccessor.SaveUser(new UserEntity() { BithdayDate = model.BithdayDate, UserName = model.UserName, UserSurname = model.UserSurname });

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
    }
}