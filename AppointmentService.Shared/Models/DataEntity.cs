using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Shared.Models
{
    public class DataEntity
    {
        public string UserName { get; set; }
        
        public string UserSurname { get; set; }
        
        public DateTime BithdayDate { get; set; }

        public int Id { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public int PhysicalActiveType { get; set; }
        
        public int Gender { get; set; }

        public int UserId { get; set; }
    }
}
