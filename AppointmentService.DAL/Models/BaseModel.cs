using System;
namespace AppointmentService.DAL.Models
{
    public class BaseModel : IBaseModel
    {
       public int Id { get; set; }

       public DateTime CreatedOn { get; set; }
    }
}
