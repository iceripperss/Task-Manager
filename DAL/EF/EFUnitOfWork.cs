using System;
using DAL.Repository.IMPL;
using DAL.Repository.Interfaces;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private CatalogContext db;
        private CatalogRepository catalogRepository;
        private TaskRepository taskRepository;

        public EFUnitOfWork(CatalogContext context)
        {
            db = context;
        }
        public ICatalogRepository Catalogs
        {
            get
            {
                if (catalogRepository == null)
                    catalogRepository = new CatalogRepository(db);
                return catalogRepository;
            }
        }

        public ITaskRepository Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository(db);
                return taskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}