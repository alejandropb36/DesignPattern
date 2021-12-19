using DesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.RepositoryPattern
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> Get();
        Beer Get(int id);
        void Add(Beer beer);
        void Delete(int id);
        void Update(Beer beer);
        void Save();
    }
}
