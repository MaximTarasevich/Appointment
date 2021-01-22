using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AppointmentService.DAL
{
    public class DBContextFactory
    {
        const string ConnectionString = "MySQLConnectionString";


        public static DataManager BuildDataManager(IConfiguration _configuration)
        {
            DataManager _dm = new DataManager(true);

            DbContextOptionsBuilder bld = new DbContextOptionsBuilder(new Microsoft.EntityFrameworkCore.DbContextOptions<AppointmentService.DAL.RepositoryContext>());
            bld = bld.UseMySql(_configuration.GetValue<string>(ConnectionString), // replace with your Connection String
                   mysqlOptions =>
                   {
                       mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                   });



            AppointmentService.DAL.RepositoryContext _context = new AppointmentService.DAL.RepositoryContext(bld.Options as Microsoft.EntityFrameworkCore.DbContextOptions<AppointmentService.DAL.RepositoryContext>);

            _dm.DataAccessor = new Accessors.DataAccessor(_context);
            _dm.UserAccessor = new Accessors.UserAccessor(_context);


            return _dm;
        }



    }
}
