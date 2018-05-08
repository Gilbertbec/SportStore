namespace Vic.SportsStore.Domain.Concrete
{
    using System.Data.Entity;
    using Vic.SportsStore.Domain.Entities;

    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("abc")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
