using System;
namespace AppointmentService.DAL.Models
{
    public class Hospital : BaseModel
    {
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
