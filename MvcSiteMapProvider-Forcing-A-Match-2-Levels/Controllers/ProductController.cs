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
        public ActionResult Details(int productId)
        {
            var db = new CRUDExample();
            var model = (from product in db.Product
                         where product.Id == productId
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
                var model = new Product();
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

        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Edit(int productId)
        {
            

            var db = new CRUDExample();
            var model = (from product in db.Product
                         where product.Id == productId
                         select product).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Edit(int productId, Product product)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from p in db.Product
                             where p.Id == productId
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

        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int productId)
        {
            var db = new CRUDExample();
            var model = (from product in db.Product
                         where product.Id == productId
                         select product).FirstOrDefault();
            return View(model);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        [SiteMapTitle("Name", Target = AttributeTarget.ParentNode)]
        public ActionResult Delete(int productId, Product product)
        {
            try
            {
                var db = new CRUDExample();
                var model = (from p in db.Product
                             where p.Id == productId
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
