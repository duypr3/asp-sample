using Entity.Default;
using System.Data.Entity;

namespace Entity
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Class> Classes { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Login> Logins { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}