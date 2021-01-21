using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppointmentService.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppointmentService.DAL.Accessors
{
    public abstract class BaseAccessor<TEntity> : IDisposable, IBaseAccessor<TEntity> where TEntity : class, IBaseModel, new()
    {
        public BaseAccessor(RepositoryContext db)
        {
            this.Context = db ?? throw new ArgumentNullException("DbContext", "DbContext is null");
            this.DbSet = db.Set<TEntity>();
        }

        protected RepositoryContext Context { get; private set; }
        protected DbSet<TEntity> DbSet { get; private set; }
        public IQueryable<TEntity> Query { get { return this.DbSet.AsQueryable(); } }

        public async Task<int> ExecuteSqlCmd(string cmd)
        {
            return await Context.Database.ExecuteSqlRawAsync(cmd);
        }
        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public async Task<int> DeleteEntity(int id)
        {
            var entity = await DbSet.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                Context.Remove(entity);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<TEntity> Remove(TEntity value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value", "value is null");
            }

            var data = this.Context.Set<TEntity>().Remove(value);

            return null;
        }
        public async Task<TEntity> SaveEntity(TEntity value)
        {
            try
            {

                if (null == value)
                {
                    throw new ArgumentNullException("value", "value is null");
                }

                Type tEntity = typeof(TEntity);

                EntityEntry<TEntity> entityEntry = null;

                if (value.Id <= 0)
                {
                    value.CreatedOn = DateTime.UtcNow;
                    entityEntry = DbSet.Add(value);
                    Context.Entry(value).State = EntityState.Added;
                }
                else
                {

                    var entity = await DbSet.FirstOrDefaultAsync(e => e.Id == value.Id);
                    if (entity == null)
                    {

                        value.CreatedOn = DateTime.UtcNow;
                        entityEntry = DbSet.Add(value);
                        Context.Entry(value).State = EntityState.Added;
                    }
                    else
                    {
                        EntityEntry<TEntity> dbEntryValue = Context.Entry(value);
                        EntityEntry<TEntity> dbEntryEntity = Context.Entry(entity);

                        if (dbEntryValue.State == EntityState.Detached)
                        {
                            Context.Entry(entity).Reload();
                        }

                        EntityState entValue = Context.Entry(value).State;

                        Context.Entry(entity).CurrentValues.SetValues(value);
                        Context.Entry(entity).State = EntityState.Modified;
                    }

                }


                var res = await Context.SaveChangesAsync();

                return await DbSet.FirstOrDefaultAsync(e => e.Id == value.Id);


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Context != null && Context.Database != null)
                    {
                        Context.Database.CloseConnection();
                    }
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
