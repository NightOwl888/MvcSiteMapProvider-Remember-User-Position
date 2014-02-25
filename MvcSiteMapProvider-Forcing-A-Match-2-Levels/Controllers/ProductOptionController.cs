using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider_CRUD_Example.Entity;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace MvcSiteMapProvider_Forcing_A_Match_2_Levels.Controllers
{
    public class ProductOptionController : Controller
    {
        //
        // GET: /ProductOption/Create

        public ActionResult Create(int productId)
        {
            // Set the Product Node's Title
            SetNodeTitle(GetProductName(productId), 2);
            return View();
        }

        //
        // POST: /ProductOption/Create

        [HttpPost]
        public ActionResult Create(int productId, ProductOption productOption)
        {
            try
            {
                var db = new CRUDExample();
                var model = new ProductOption();
                if (model != null)
                {
                    model.ProductId = productId;
                    model.Name = productOption.Name;

                    db.ProductOption.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "Product", new { productId = productId });
            }
            catch
            {
                // Set the Product Node's Title
                SetNodeTitle(GetProductName(productId), 2);
                return View();
            }
        }

        //
        // GET: /ProductOption/Edit/5

        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Edit(int productOptionId, int productId)
        {
            // Set the Product Node's Title
            SetNodeTitle(GetProductName(productId), 3);

            var db = new CRUDExample();
            var model = (from productOption in db.ProductOption
                         where productOption.Id == productOptionId
                         select productOption).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /ProductOption/Edit/5

        [HttpPost]
        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Edit(int productOptionId, int productId, ProductOption productOption)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from po in db.ProductOption
                             where po.Id == productOptionId
                             select po).FirstOrDefault();
                if (model != null)
                {
                    model.Name = productOption.Name;

                    db.SaveChanges();
                }

                return RedirectToAction("Details", "Product", new { productId = productId });
            }
            catch
            {
                // Set the Product Node's Title
                SetNodeTitle(GetProductName(productId), 3);
                return View();
            }
        }

        //
        // GET: /ProductOption/Delete/5

        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int productOptionId, int productId)
        {
            // Set the Product Node's Title
            SetNodeTitle(GetProductName(productId), 3);

            var db = new CRUDExample();
            var model = (from productOption in db.ProductOption
                         where productOption.Id == productOptionId
                         select productOption).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /ProductOption/Delete/5

        [HttpPost]
        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int productOptionId, int productId, ProductOption productOption)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from po in db.ProductOption
                             where po.Id == productOptionId
                             select po).FirstOrDefault();
                if (model != null)
                {
                    db.ProductOption.Remove(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "Product", new { productId = productId });
            }
            catch
            {
                // Set the Product Node's Title
                SetNodeTitle(GetProductName(productId), 3);
                return View();
            }
        }


        private string GetProductName(int productId)
        {
            using (var db = new CRUDExample())
            {
                return (from p in db.Product
                        where p.Id == productId
                        select p.Name).FirstOrDefault();
            }
        }

        private void SetNodeTitle(string title, int ancestorLevel)
        {
            ISiteMapNode node = SiteMaps.Current.CurrentNode;
            if (node != null)
            {
                for (int i = 0; i < ancestorLevel; i++)
                {
                    if (node.ParentNode != null)
                    {
                        node = node.ParentNode;
                    }
                }

                node.Title = title;
            }
        }
    }
}
