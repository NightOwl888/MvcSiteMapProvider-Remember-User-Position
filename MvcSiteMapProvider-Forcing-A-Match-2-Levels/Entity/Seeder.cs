using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcSiteMapProvider_CRUD_Example.Entity
{
    public class Seeder
        : DropCreateDatabaseAlways<CRUDExample>
    {
        protected override void Seed(CRUDExample context)
        {
            SeedProduct(context);
            SeedProductOption(context);
        }

        private void SeedProduct(CRUDExample context)
        {
            var table = new List<Product>
            {
                new Product { Id = 1, Name = "AA Battery" },
                new Product { Id = 2, Name = "Raincoat" },
                new Product { Id = 3, Name = "Boots" },
                new Product { Id = 4, Name = "Waterproof Matches" },
                new Product { Id = 5, Name = "Flashlight" }
            };
            table.ForEach(x => context.Product.Add(x));
            context.SaveChanges();
        }

        private void SeedProductOption(CRUDExample context)
        {
            var table = new List<ProductOption>
            {
                new ProductOption { Id = 1, ProductId = 2, Name = "Color" },
                new ProductOption { Id = 2, ProductId = 2, Name = "Size" },
                new ProductOption { Id = 3, ProductId = 3, Name = "Color" },
                new ProductOption { Id = 4, ProductId = 3, Name = "Size" }
            };
            table.ForEach(x => context.ProductOption.Add(x));
            context.SaveChanges();
        }
    }
}