using System;
using AppointmentService.DAL.Accessors;

namespace AppointmentService.DAL
{
    public class DataManager : IDisposable
    {
        public AddressAccessor AddressAccessor { get; set; }

        public AppointmentAccessor AppointmentAccessor { get; set; }

        public DoctorAccessor DoctorAccessor { get; set; }

        public HospitalAccessor HospitalAccessor { get; set; }

        public SpecializationAccessor SpecializationAccessor { get; set; }
        public DataManager(AddressAccessor aotFA, AppointmentAccessor AA, DoctorAccessor CA, HospitalAccessor DSIA, SpecializationAccessor EA)
        {
            AddressAccessor = aotFA;
            AppointmentAccessor = AA;
            DoctorAccessor = CA;
            HospitalAccessor = DSIA;
            SpecializationAccessor = EA;
        }

        public DataManager(bool init)
        {

        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
