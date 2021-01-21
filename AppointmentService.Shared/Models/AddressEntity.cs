using System;
namespace AppointmentService.Shared.Models
{
    public class AddressEntity
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Town { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }
    }
}
