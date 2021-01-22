using System;
namespace AppointmentService.DAL.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime BithdayDate { get; set; }
    }
}
