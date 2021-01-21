using System;
using System.Collections.Generic;
using System.Linq;
using AppointmentService.DAL.Models;
using AppointmentService.Shared.Models;

namespace AppointmentService.DAL.Converters
{
    public static class AppointmentConverter
    {
        public static Appointment ToAppointment(this AppointmentEntity newEntity, Appointment oldEntity = null)
        {
            Appointment entity = oldEntity;
            if (entity == null)
            {
                entity = new Appointment();

            }

            entity.HospitalId = newEntity.HospitalId;
            entity.DoctorId = newEntity.DoctorId;
            entity.TimeStart = newEntity.TimeStart;

            entity.TimeEnd = newEntity.TimeEnd;
            entity.PacientName = newEntity.PacientName;
            entity.PacientSurname = newEntity.PacientSurname;
            entity.PacientPhone = newEntity.PacientPhone;
            return entity;
        }


        public static AppointmentEntity ToAppointmentEntity(this Appointment model)
        {
            if (model == null)
                return null;

            AppointmentEntity entity = new AppointmentEntity();

            entity.Id = model.Id;
            entity.HospitalId = model.HospitalId;
            entity.DoctorId = model.DoctorId;
            entity.TimeStart = model.TimeStart;

            entity.TimeEnd = model.TimeEnd;
            entity.PacientName = model.PacientName;
            entity.PacientSurname = model.PacientSurname;
            entity.PacientPhone = model.PacientPhone;

            return entity;
        }

        public static IEnumerable<AppointmentEntity> ToAppointmentEntityCollection(this IEnumerable<Appointment> items)
        {
            List<AppointmentEntity> models = new List<AppointmentEntity>();
            if (items == null)
                return models;

            models.AddRange(items.Select(e => e.ToAppointmentEntity()));

            return models;
        }
    }
}
