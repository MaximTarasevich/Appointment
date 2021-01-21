using System;
namespace AppointmentService.Shared.Models
{
    public class HospitalEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }
    }
}
