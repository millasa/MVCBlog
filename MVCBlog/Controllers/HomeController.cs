using MVCBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        private MVCBlogContext db = new MVCBlogContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
