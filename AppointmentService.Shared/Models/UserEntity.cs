using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Shared.Models
{
    public class UserEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public DateTime BithdayDate { get; set; }

        public int Age { get; set; }

        public object BirthdayDate { get; set; }
    }
}
