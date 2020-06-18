using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HIS.Models;
namespace HIS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer<StudentDbContext>(null);


            int retObj = 0;
            using (StudentDbContext entities = new StudentDbContext())
            {
                //Truncate Table to delete all old records.
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [studentSubjects]");
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [classMasters]");
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [subjectMasters]");
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [studentRegistrations]");

                //entities.Database.ExecuteSqlCommand("drop TABLE [studentSubjects]");
                //entities.Database.ExecuteSqlCommand("drop TABLE [studentClasses]");
                //entities.Database.ExecuteSqlCommand("drop TABLE [students]");
            }

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
