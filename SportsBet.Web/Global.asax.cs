using SportsBet.App_Start;
using SportsBet.Data;
using SportsBet.Data.Migrations;
//using SportsBet.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SportsBet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<SportsBetContext>(null);

            using (var db = new SportsBetContext())
            {
                db.Database.Initialize(false);
            }

            var migrator = new DbMigrator(new Configuration());

            if (migrator.GetPendingMigrations().Any())
            {
                migrator.Update();
            }

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportsBetContext, Configuration>());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mapper = new AutoMapperConfig();
            mapper.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
