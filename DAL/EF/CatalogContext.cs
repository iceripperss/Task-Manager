using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class CatalogContext
        : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public CatalogContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}