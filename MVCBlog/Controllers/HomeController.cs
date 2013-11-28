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

        public ActionResult Index()
        {
            /*SELECT Categories.CategoryName, COUNT(Articles.ArticleId) AS NumberOfArticles FROM Articles
              LEFT JOIN Categories
              ON Categories.CategoryId=Articles.CategoryId
              GROUP BY CategoryName;*/

            var q = from c in db.Categories
                    join a in db.Articles on c.CategoryId equals a.CategoryId into ca
                    select new CategoryInfo
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName,
                        ArticleCount = ca.Count()
                    };

            return View(q.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
