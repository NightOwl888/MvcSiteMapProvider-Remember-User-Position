using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider_CRUD_Example.Entity;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace MvcSiteMapProvider_CRUD_Example.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            var db = new CRUDExample();
            var model = (from product in db.Product
                            select product).ToList();


            return View(model);
        }

        //
        // GET: /Product/Details/5

        [SiteMapTitle("Name")]
        public ActionResult Details(int id)
        {
            ISiteMapNode node;
            node = SiteMaps.Current.FindSiteMapNodeFromKey("Product_Details");
            if (node != null)
            {
                node.RouteValues.Add("id", id);
            }

            var db = new CRUDExample();
            var model = (from product in db.Product
                        where product.Id == id
                        select product).FirstOrDefault();

            return View(model);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var db = new CRUDExample();
                var model = new Entity.Product();
                if (model != null)
                {
                    model.Name = product.Name;

                    db.Product.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id)
        {
            var node1 = SiteMaps.Current.FindSiteMapNodeFromKey("Product_Edit");
            if (node1 != null)
            {
                // Set the id of the Edit node
                node1.RouteValues["id"] = id;
                var parent = node1.ParentNode;
                if (parent != null)
                {
                    // Set the id of the Details node
                    parent.RouteValues["id"] = id;
                }
            }

            var db = new CRUDExample();
            var model = (from product in db.Product
                         where product.Id == id
                         select product).FirstOrDefault();

            // Now that we have set the id, the match works for current node
            var node = SiteMaps.Current.CurrentNode;
            if (node != null)
            {
                // Set a custom attribute - we can set this to any object
                node.Attributes["CustomKey"] = "SomeCustomValue";

                // Set the title and description of the Details node based on database data
                var parent = node.ParentNode;
                if (parent != null)
                {
                    parent.Title = model.Name;
                    parent.Description = model.Name;
                }
            }

            return View(model);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from p in db.Product
                             where p.Id == id
                             select p).FirstOrDefault();
                if (model != null)
                {
                    model.Name = product.Name;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // Set our navigation again, or it will be lost - these values disappear
                // on each request and need to be restored if we go back to the same view.
                var node1 = SiteMaps.Current.FindSiteMapNodeFromKey("Product_Edit");
                if (node1 != null)
                {
                    // Set the id of the Edit node
                    node1.RouteValues["id"] = id;
                    var parent = node1.ParentNode;
                    if (parent != null)
                    {
                        // Set the id of the Details node
                        parent.RouteValues["id"] = id;

                        // Set the title and description of the Details node based on postback data
                        parent.Title = product.Name;
                        parent.Description = product.Name;
                    }

                    // Set a custom attribute - we can set this to any object
                    node1.Attributes["CustomKey"] = "SomeCustomValue";
                }
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int id)
        {
            var node1 = SiteMaps.Current.FindSiteMapNodeFromKey("Product_Delete");
            if (node1 != null)
            {
                // Set the id of the Edit node
                node1.RouteValues["id"] = id;
                var parent = node1.ParentNode;
                if (parent != null)
                {
                    // Set the id of the Details node
                    parent.RouteValues["id"] = id;
                }
            }

            var db = new CRUDExample();
            var model = (from product in db.Product
                        where product.Id == id
                        select product).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from p in db.Product
                             where p.Id == id
                             select p).FirstOrDefault();
                if (model != null)
                {
                    db.Product.Remove(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // Set our navigation again, or it will be lost - these values disappear
                // on each request and need to be restored if we go back to the same view.
                var node1 = SiteMaps.Current.FindSiteMapNodeFromKey("Product_Delete");
                if (node1 != null)
                {
                    // Set the id of the Edit node
                    node1.RouteValues["id"] = id;
                    var parent = node1.ParentNode;
                    if (parent != null)
                    {
                        // Set the id of the Details node
                        parent.RouteValues["id"] = id;
                    }
                }

                return View();
            }
        }
    }
}
