using System;
namespace AppointmentService.DAL.Models
{
    public class Appointment : BaseModel
    {
        public int HospitalId { get; set; }

        public int DoctorId { get; set; }

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public string PacientName { get; set; }
        public string PacientSurname { get; set; }
        public string PacientPhone { get; set; }
    }
}
