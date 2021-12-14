using DAL.EF;
using DAL.Entities;
using DAL.Repository.Interfaces;

namespace DAL.Repository.IMPL
{
    public class CatalogRepository
        : BaseRepository<Catalog>, ICatalogRepository
    {

        internal CatalogRepository(CatalogContext context) 
            : base(context)
        {
        }
    }
}