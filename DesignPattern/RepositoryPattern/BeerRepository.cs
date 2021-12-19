using DesignPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern.RepositoryPattern
{
    public class BeerRepository : IBeerRepository
    {
        private DesignPatternsContext _designPatternsContext;

        public BeerRepository(DesignPatternsContext designPatternsContext)
        {
            _designPatternsContext = designPatternsContext;
        }

        public void Add(Beer beer) => _designPatternsContext.Beer.Add(beer);

        public void Delete(int id)
        {
            var beer = _designPatternsContext.Beer.Find(id);
            _designPatternsContext.Beer.Remove(beer);
        }

        public IEnumerable<Beer> Get() => _designPatternsContext.Beer.ToList();

        public Beer Get(int id) => _designPatternsContext.Beer.Find(id);

        public void Save() => _designPatternsContext.SaveChanges();

        public void Update(Beer beer) => _designPatternsContext.Entry(beer).State = EntityState.Modified;
    }
}
