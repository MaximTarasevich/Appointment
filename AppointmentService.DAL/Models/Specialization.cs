using System;
namespace AppointmentService.DAL.Models
{
    public class Specialization : BaseModel
    {
        public string Name { get; set; }

        public int HospitalId { get; set; }
    }
}
