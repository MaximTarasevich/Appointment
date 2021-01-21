using System;
namespace AppointmentService.DAL.Models
{
    public interface IBaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
