using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSiteMapProvider_CRUD_Example.Entity
{
    public class ProductOption
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
}