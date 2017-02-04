namespace Entity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class DefaultConfiguration : DbMigrationsConfiguration<Entity.DefaultDbContext>
    {
        public DefaultConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entity.DefaultDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

    internal sealed class DataMiningConfiguration : DbMigrationsConfiguration<Entity.DataMiningDbContext>
    {
        public DataMiningConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Entity.DataMiningDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }

}