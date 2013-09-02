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

        public ActionResult Details(int id)
        {
            ISiteMapNode node;
            node = SiteMaps.Current.FindSiteMapNodeFromKey("Details");
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
            var db = new CRUDExample();
            var model = (from product in db.Product
                         where product.Id == id
                         select product).FirstOrDefault();

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
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            var db = new CRUDExample();
            var model = (from product in db.Product
                        where product.Id == id
                        select product).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
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
                return View();
            }
        }
    }
}
