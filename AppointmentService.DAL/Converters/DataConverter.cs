using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;

namespace AppointmentService.DAL.Converters
{
    public static class DataConverter
    {
        public static Data ToData(this DataEntity newEntity, Data oldEntity = null)
        {
            Data entity = oldEntity;
            if (entity == null)
            {
                entity = new Data();

            }

            entity.Gender = newEntity.Gender;
            entity.PhysicalActiveType = newEntity.PhysicalActiveType;
            entity.UserId = newEntity.UserId;
            entity.Age = newEntity.Age;

            return entity;
        }


        public static DataEntity ToDataEntity(this Data model)
        {
            if (model == null)
                return null;

            DataEntity entity = new DataEntity();

            entity.Id = model.Id;
            entity.Gender = model.Gender;
            entity.PhysicalActiveType = model.PhysicalActiveType;
            entity.UserId = model.UserId;

            return entity;
        }

        public static IEnumerable<DataEntity> ToDataEntityCollection(this IEnumerable<Data> items)
        {
            List<DataEntity> models = new List<DataEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToDataEntity()));

            return models;
        }
    }
}
