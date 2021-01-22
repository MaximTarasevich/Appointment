using System;
namespace AppointmentService.DAL.Models
{
    public class Data : BaseModel
    {
        public int PhysicalActiveType { get; set; }

        public int Gender { get; set; }

        public int UserId { get; set; }
    }
}
