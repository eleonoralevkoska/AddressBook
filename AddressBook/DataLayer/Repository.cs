using AddressBook.DtoModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AddressBook.DataLayer
{
    public abstract class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AddressBookDbContext _context;
        public Repository(AddressBookDbContext context)
        {
            _context = context;
        }       
        protected void Save() => _context.SaveChanges();
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }
        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
            
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public List<T> GetAll(Func<IQueryable<T>, IQueryable<T>> func = null)
        {
            var dbSet = _context.Set<T>();
            if (func != null)
            {
                return func(dbSet).ToList();
            }
            return dbSet.ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}