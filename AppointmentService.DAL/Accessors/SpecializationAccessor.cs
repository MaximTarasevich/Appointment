using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{

    public class SpecializationAccessor : BaseAccessor<Specialization>
    {
        public SpecializationAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<SpecializationEntity> GetSpecialization(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToSpecializationEntity();
        }

        public async Task<SpecializationEntity> SaveSpecializationEntity(SpecializationEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToSpecialization(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToSpecialization(_item)));
            }
            return await GetSpecialization(_item.Id);
        }

        public async Task<List<SpecializationEntity>> GetSpecializationEntitys()
        {

            return (await Query.ToListAsync()).ToSpecializationEntityCollection().ToList();
        }

        public async Task<int> GetSpecializationCount()
        {
            return await Query.CountAsync();
        }



    }
}
