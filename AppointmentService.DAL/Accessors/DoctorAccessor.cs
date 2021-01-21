using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class DoctorAccessor : BaseAccessor<Doctor>
    {
        public DoctorAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<DoctorEntity> GetDoctor(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToDoctorEntity();

        }
        public async Task<DoctorEntity> SaveDoctor(DoctorEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToDoctor(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToDoctor(_item)));
            }
            return await GetDoctor(_item.Id);
        }

        public async Task<List<DoctorEntity>> GetDoctors()
        {


            return (await Query.ToListAsync()).ToDoctorEntityCollection().ToList();
        }

        public async Task<int> GetAppointmentsCount()
        {
            return await Query.CountAsync();
        }



    }
}
