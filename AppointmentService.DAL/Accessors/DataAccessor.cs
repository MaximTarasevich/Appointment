using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class DataAccessor : BaseAccessor<Data>
    {
        public DataAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<DataEntity> GetData(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToDataEntity();
        }

        public async Task<DataEntity> SaveAddress(DataEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToData(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToData(_item)));
            }
            return await GetData(_item.Id);
        }

        public async Task<List<DataEntity>> GetData()
        {


            return (await Query.ToListAsync()).ToDataEntityCollection().ToList();
        }

        public async Task<int> GetDataCount()
        {
            return await Query.CountAsync();
        }



    }
}
