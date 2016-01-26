using IdentityPractice.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace IdentityPractice.Infrastructure {
    public class GenericRepository<T> where T : class, IDbEntity, IActivatable {

        //we only want repositories that extend DbContext to be able to access it
        protected DbContext _db;

        protected IQueryable<T> Table {
            get {
                return _db.Set<T>();
            }
        }

        public GenericRepository(DbContext db) {
            _db = db;
        }

        public IList<T> List() {
            return (from e in Table
                    where e.Active
                    select e).ToList();
            //_db.Set<T>().ToList();
        }

        public T Get(int id) {
            return (from e in Table
                    where e.Active && e.Id == id
                    select e).FirstOrDefault();
        }
        //public T Get(params object[] keys) {
        //    return _db.Set<T>().Find(keys);
        //}

        public void Add(T entity) {
            _db.Set<T>().Add(entity);
        }

        public void Delete(int id) {
            //_db.Set<T>().Remove(entity);
            Delete(Get(id));
        }

        public void Delete(T entity) {
            //_db.Set<T>().Remove(entity);
            entity.Active = false;
        }

        public void SaveChanges() {
            try {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException dbError) {
                var firstError = dbError.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new DbEntityValidationException(firstError);
            }
        }
    }
}