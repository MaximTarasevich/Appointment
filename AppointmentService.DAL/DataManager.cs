using System;
using AppointmentService.DAL.Accessors;

namespace AppointmentService.DAL
{
    public class DataManager : IDisposable
    {
        public DataAccessor DataAccessor { get; set; }

        public UserAccessor UserAccessor { get; set; }

        public DataManager(DataAccessor aotFA, UserAccessor AA)
        {
            DataAccessor = aotFA;
            UserAccessor = AA;

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
