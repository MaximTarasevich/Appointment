using System;
namespace AppointmentService.Shared.Models
{
    public class DoctorEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public int HospitalId { get; set; }
        public HospitalEntity Hospital { get; set; }

        public int SpecializationId { get; set; }
        public SpecializationEntity Specialization { get; set; }
    }
}
