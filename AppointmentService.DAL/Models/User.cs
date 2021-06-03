using System;
namespace AppointmentService.DAL.Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime BirthdayDate { get; set; }
        public int Age { get; internal set; }
    }
}
