using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;
using Hotel.Models.Context;
using System.Data.Entity;

namespace Hotel.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        DbHotelContext db;
        DbSet<T> dbSet;
        public GenericRepository(DbHotelContext context)
        {
            db = context;
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetEntity(int id)
        {
            return dbSet.Find(id);
        }

        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = GetEntity(id);
                db.Entry(entity).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
