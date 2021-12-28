using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private DesignPatternsContext _designPatternsContext;
        private DbSet<TEntity> _dbSet;

        public Repository(DesignPatternsContext designPatternsContext)
        {
            _designPatternsContext = designPatternsContext;
            _dbSet = _designPatternsContext.Set<TEntity>();
        }

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public IEnumerable<TEntity> Get() => _dbSet.ToList();

        public TEntity Get(int id) => _dbSet.Find(id);

        public void Save() => _designPatternsContext.SaveChanges();

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _designPatternsContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
