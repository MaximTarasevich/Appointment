using System;
namespace AppointmentService.DAL.Models
{
    public class Doctor : BaseModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}
