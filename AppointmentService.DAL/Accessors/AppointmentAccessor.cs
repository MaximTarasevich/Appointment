using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class AppointmentAccessor : BaseAccessor<Appointment>
    {
        public AppointmentAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<AppointmentEntity> GetAppointment(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToAppointmentEntity();
        }

        public async Task<AppointmentEntity> SaveAppointment(AppointmentEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToAppointment(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToAppointment(_item)));
            }
            return await GetAppointment(_item.Id);
        }

        public async Task<List<AppointmentEntity>> GetAppointments()
        {


            return (await Query.ToListAsync()).ToAppointmentEntityCollection().ToList();
        }

        public async Task<int> GetAppointmentsCount()
        {
            return await Query.CountAsync();
        }



    }
}
