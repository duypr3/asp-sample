using Entity.DataMining;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DataMiningDbContext : DbContext
    {
        public DataMiningDbContext() : base("DataMiningConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<AccountSync> AccountSyncs { set; get; }
        public DbSet<TeacherSync> TeacherSyncs { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
