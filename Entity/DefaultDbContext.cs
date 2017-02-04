using Entity.Default;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Class> Classes { set; get; }
        public DbSet<Teacher> Teachers { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
