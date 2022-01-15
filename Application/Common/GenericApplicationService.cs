using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common
{
    public class GenericApplicationService<T> where T : class, IIdentity
    {
        protected readonly ApplicationDbContext dbContext;
        public GenericApplicationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            dbContext.Set<T>().Load();
            var result = dbContext.Set<T>().ToList();
            
            return result;
        }

        public virtual T GetById(int id)
        {
            var result = dbContext.Set<T>().Where(x => x.Id == id);

            if (result == null)
            {
                throw new KeyNotFoundException();
            }

            return result.FirstOrDefault();
        }

        public virtual T Create(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();

            return GetById(entity.Id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
