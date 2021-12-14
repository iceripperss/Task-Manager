using System;
using DAL.Entities;
using DAL.Repository.IMPL;
using DAL.Repository.Interfaces;

namespace DAL.EF
{
    public interface IUnitOfWork : IDisposable
    {
        ICatalogRepository Catalogs { get; }
        ITaskRepository Tasks { get; }
        void Save();
    }
}