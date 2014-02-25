using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcSiteMapProvider_CRUD_Example.Entity
{
    public class CRUDExample
        : DbContext
    {
        // Database Schema
        public IDbSet<Product> Product { get; set; }
        public IDbSet<ProductOption> ProductOption { get; set; }
    }

}