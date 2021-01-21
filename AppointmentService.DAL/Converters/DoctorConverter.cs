using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;
namespace AppointmentService.DAL.Converters
{
    public static class DoctorConverter
    {
        public static Doctor ToDoctor(this DoctorEntity newEntity, Doctor oldEntity = null)
        {
            Doctor entity = oldEntity;
            if (entity == null)
            {
                entity = new Doctor();

            }

            entity.Name = newEntity.Name;
            entity.Surname = newEntity.Surname;
            entity.HospitalId = newEntity.HospitalId;
            entity.SpecializationId = newEntity.SpecializationId;
            return entity;
        }


        public static DoctorEntity ToDoctorEntity(this Doctor model)
        {
            if (model == null)
                return null;

            DoctorEntity entity = new DoctorEntity();

            entity.Id = model.Id;
            entity.HospitalId = model.HospitalId;
            entity.Name = model.Name;
            entity.Surname = model.Surname;

            entity.SpecializationId = model.SpecializationId;

            return entity;
        }

        public static IEnumerable<DoctorEntity> ToDoctorEntityCollection(this IEnumerable<Doctor> items)
        {
            List<DoctorEntity> models = new List<DoctorEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToDoctorEntity()));

            return models;
        }
    }
}
