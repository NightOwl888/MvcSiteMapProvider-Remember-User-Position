using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class DbConfig
{
    public static void Register()
    {
        // TODO: Remove the initializer before deploying to production
        Database.SetInitializer(new MvcSiteMapProvider_CRUD_Example.Entity.Seeder());
    }
}
