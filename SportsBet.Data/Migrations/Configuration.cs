namespace SportsBet.Data.Migrations
{
    using SportsBet.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SportsBet.Data.SportsBetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsBet.Data.SportsBetContext context)
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
            context.Events.Add(new Event(8, "Liverpool - Juventus", 1.95, 3.15, 2.20, new DateTime(2018, 12, 25, 21, 0, 0)));
            context.Events.Add(new Event(13, "Grigor Dimitrov - Rafael Nadal", 1.95, 3.05, 2.70, new DateTime(2018, 6, 6, 19, 0, 0)));
            context.Events.Add(new Event(21, "Barcelona - Ludogorets", 1.00, 4.20, 15.20, new DateTime(1055, 12, 31, 18, 30, 0)));
            base.Seed(context);
        }
    }
}
