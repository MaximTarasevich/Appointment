using System;
namespace AppointmentService.Shared.Models
{
    public class SpecializationEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Name { get; set; }

        public int HospitalId { get; set; }
    }
}
