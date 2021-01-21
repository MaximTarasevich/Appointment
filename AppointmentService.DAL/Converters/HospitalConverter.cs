using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
namespace AppointmentService.DAL.Converters
{
    public static class HospitalConverter
    {
        public static Hospital ToHospital(this HospitalEntity newEntity, Hospital oldEntity = null)
        {
            Hospital entity = oldEntity;
            if (entity == null)
            {
                entity = new Hospital();

            }

            entity.AddressId = newEntity.AddressId;
            return entity;
        }


        public static HospitalEntity ToHospitalEntity(this Hospital model)
        {
            if (model == null)
                return null;

            HospitalEntity entity = new HospitalEntity();

            entity.Id = model.Id;
            entity.AddressId = model.AddressId;


            return entity;
        }

        public static IEnumerable<HospitalEntity> ToHospitalEntityCollection(this IEnumerable<Hospital> items)
        {
            List<HospitalEntity> models = new List<HospitalEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToHospitalEntity()));

            return models;
        }
    }
}
