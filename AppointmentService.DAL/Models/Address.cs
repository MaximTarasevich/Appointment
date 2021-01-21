using System;
namespace AppointmentService.DAL.Models
{
    public class Address : BaseModel
    {
        public string Town { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }
    }
}
