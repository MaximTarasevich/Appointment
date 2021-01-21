using System;
using AppointmentService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AppointmentService.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Address> AOTFilters { get; set; }
        public DbSet<Appointment> Authors { get; set; }
        public DbSet<Doctor> Cameras { get; set; }
        public DbSet<Hospital> dSTORMInfos { get; set; }
        public DbSet<Specialization> Experiments { get; set; }
        public void Close()
        {
            try
            {
                this.Database.CloseConnection();
                this.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
