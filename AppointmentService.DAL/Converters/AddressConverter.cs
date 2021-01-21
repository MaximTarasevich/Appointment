using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;

namespace AppointmentService.DAL.Converters
{
    public static class AddressConverter
    {
        public static Address ToAddress(this AddressEntity newEntity, Address oldEntity = null)
        {
            Address entity = oldEntity;
            if (entity == null)
            {
                entity = new Address();

            }

            entity.Town = newEntity.Town;
            entity.Street = newEntity.Street;
            entity.Number = newEntity.Number;

            return entity;
        }


        public static AddressEntity ToAddressEntity(this Address model)
        {
            if (model == null)
                return null;

            AddressEntity entity = new AddressEntity();

            entity.Id = model.Id;
            entity.Town = model.Town;
            entity.Street = model.Street;
            entity.Number = model.Number;

            return entity;
        }

        public static IEnumerable<AddressEntity> ToAddressEntityCollection(this IEnumerable<Address> items)
        {
            List<AddressEntity> models = new List<AddressEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToAddressEntity()));

            return models;
        }
    }
}
