using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
namespace AppointmentService.DAL.Converters
{
    public static class UserConverter
    {
        public static User ToUser(this UserEntity newEntity, User oldEntity = null)
        {
            User entity = oldEntity;
            if (entity == null)
            {
                entity = new User();

            }

            entity.UserName = newEntity.UserName;
            entity.UserSurname = newEntity.UserSurname;
            entity.BirthdayDate = newEntity.BithdayDate;
            entity.Age = newEntity.Age;
            return entity;
        }


        public static UserEntity ToUserEntity(this User model)
        {
            if (model == null)
                return null;

            UserEntity entity = new UserEntity();

            entity.Id = model.Id;
            entity.UserName = model.UserName;
            entity.UserSurname = model.UserSurname;
            entity.BirthdayDate = model.BirthdayDate;
            entity.Age= model.Age;

            return entity;
        }

        public static IEnumerable<UserEntity> ToUserEntityCollection(this IEnumerable<User> items)
        {
            List<UserEntity> models = new List<UserEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToUserEntity()));

            return models;
        }
    }
}
