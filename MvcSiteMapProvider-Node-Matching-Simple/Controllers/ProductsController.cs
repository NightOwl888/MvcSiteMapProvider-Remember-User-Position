using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;

namespace MvcSiteMapProvider_Remember_User_Position.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
