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

        public DbSet<User> Users { get; set; }
        public DbSet<Data> Data { get; set; }
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
