using SportsBet.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBet.Data.Migrations
{
    class Configuration : DbMigrationsConfiguration<SportsBetContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = false;
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsBetContext context)
        {
            context.Events.Add(new Event(8, "Liverpool - Juventus", 1.95, 3.15, 2.20, DateTime.Parse("2018-12-25 22:00:00")));
            context.Events.Add(new Event(8, "Grigor Dimitrov - Rafael Nadal", 2.00, 3.05, 2.70, DateTime.Parse("2018-06-06 19:00:00")));
            context.Events.Add(new Event(8, "Barcelona - Ludogorets", 1.01, 4.20, 15.20, DateTime.Parse("1055-12-31 18:30:00")));

            context.SaveChanges();
        }
    }
}
