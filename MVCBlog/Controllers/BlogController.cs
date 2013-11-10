using MVCBlog.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class BlogController : Controller
    {
        MVCBlogContext db = new MVCBlogContext();

        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Blog/Category/<id>

        public ActionResult Category(int id = 1)
        {
            var categoryArticles = db.Categories.Include("Articles")
                                .Single(c => c.CategoryId == id);

            return View(categoryArticles);
        }

        //
        // GET: /Blog/Article/<id>

        public ActionResult Article(int id)
        {
            var article = db.Articles.Include("Comments")
                        .Single(c => c.ArticleId == id);

            return View(article);
        }

        //
        // GET: /Blog/Article/Create

        public ActionResult CreateArticle()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        //
        // POST: /Blog/Article/Create

        [HttpPost]
        public ActionResult CreateArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Article", new { id = article.ArticleId });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }

        //
        // GET: /Blog/Article/Edit/5

        public ActionResult EditArticle(int id)
        {
            var article = db.Articles.Single(c => c.ArticleId == id);

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }

        //
        // POST: /Blog/Article/Edit/5

        [HttpPost]
        public ActionResult EditArticle(int id, Article article)
        {
            if (ModelState.IsValid)
            {
                article.ArticleId = id;
                db.Entry(article).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Article", new { id = article.ArticleId });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }

        //
        // GET: /Blog/Article/Delete/5

        public ActionResult DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Blog/Article/Delete/5

        [HttpPost, ActionName("DeleteArticle")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Category", new { id = article.CategoryId });
        }
    }
}
