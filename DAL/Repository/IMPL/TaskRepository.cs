using DAL.EF;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.IMPL
{
    public class TaskRepository
        : BaseRepository<Task>, ITaskRepository
    {
        internal TaskRepository(CatalogContext context) 
            : base(context)
        {
        }
    }
}