using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class AddressAccessor : BaseAccessor<Address>
    {
        public AddressAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<AddressEntity> GetAddress(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToAddressEntity();
        }

        public async Task<AddressEntity> SaveAddress(AddressEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToAddress(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToAddress(_item)));
            }
            return await GetAddress(_item.Id);
        }

        public async Task<List<AddressEntity>> GetAddresses()
        {


            return (await Query.ToListAsync()).ToAddressEntityCollection().ToList();
        }

        public async Task<int> GetAddressesCount()
        {
            return await Query.CountAsync();
        }



    }
}
