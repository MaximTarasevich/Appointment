using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
namespace AppointmentService.DAL.Converters
{
    public static class SpecializationConverter
    {
        public static Specialization ToSpecialization(this SpecializationEntity newEntity, Specialization oldEntity = null)
        {
            Specialization entity = oldEntity;
            if (entity == null)
            {
                entity = new Specialization();

            }

            entity.Name = newEntity.Name;
            entity.HospitalId = newEntity.HospitalId;

            return entity;
        }


        public static SpecializationEntity ToSpecializationEntity(this Specialization model)
        {
            if (model == null)
                return null;

            SpecializationEntity entity = new SpecializationEntity();

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.HospitalId = model.HospitalId;


            return entity;
        }

        public static IEnumerable<SpecializationEntity> ToSpecializationEntityCollection(this IEnumerable<Specialization> items)
        {
            List<SpecializationEntity> models = new List<SpecializationEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToSpecializationEntity()));

            return models;
        }
    }
}
