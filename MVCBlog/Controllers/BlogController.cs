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
                return RedirectToAction("Category", new { id = article.CategoryId });
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }
        
        public ActionResult DeleteArticle(int id = 0)
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

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Article.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
