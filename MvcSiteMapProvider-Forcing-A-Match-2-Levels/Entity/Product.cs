using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MvcSiteMapProvider_CRUD_Example.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Product Options")]
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}