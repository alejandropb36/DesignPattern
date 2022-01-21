using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        public IRepository<Beer> Beers { get; }
        public IRepository<Brand> Brands { get; }
        public void Save();

    }
}
