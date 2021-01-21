using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class HospitalAccessor : BaseAccessor<Hospital>
    {
        public HospitalAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<HospitalEntity> GetHospital(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToHospitalEntity();

        }
        public async Task<HospitalEntity> SaveHospital(HospitalEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToHospital(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToHospital(_item)));
            }
            return await GetHospital(_item.Id);
        }

        public async Task<List<HospitalEntity>> GetHospitals()
        {


            return (await Query.ToListAsync()).ToHospitalEntityCollection().ToList();
        }

        public async Task<int> GetHospitalsCount()
        {
            return await Query.CountAsync();
        }



    }
}
