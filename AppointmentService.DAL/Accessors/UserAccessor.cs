using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentService.DAL.Converters;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.DAL.Accessors
{
    public class UserAccessor : BaseAccessor<User>
    {
        public UserAccessor(RepositoryContext db) : base(db)
        {
        }

        public async Task<UserEntity> GetUser(int id)
        {

            return (await Query.Where(e => e.Id == id).FirstOrDefaultAsync()).ToUserEntity();
        }

        public async Task<UserEntity> GetUser(string name, string surname, int age)
        {
            return (await Query.Where(e => e.UserName == name && e.UserSurname == surname && e.Age == age).FirstOrDefaultAsync()).ToUserEntity();
        }

        public async Task<UserEntity> SaveUser(UserEntity entity)
        {

            var _item = await Query.Where(e => e.Id == entity.Id).FirstOrDefaultAsync();
            if (_item == null)
            {
                _item = (await SaveEntity(entity.ToUser(null)));
            }
            else
            {
                _item = (await SaveEntity(entity.ToUser(_item)));
            }
            return await GetUser(_item.Id);
        }

        public async Task<List<UserEntity>> GetUsers()
        {


            return (await Query.ToListAsync()).ToUserEntityCollection().ToList();
        }

        public async Task<int> GetUsersCount()
        {
            return await Query.CountAsync();
        }



    }
}
