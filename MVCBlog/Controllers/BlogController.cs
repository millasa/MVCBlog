using MVCBlog.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class BlogController : Controller
    {
        MVCBlogContext db = new MVCBlogContext();

        public ActionResult Category(int id = 1)
        {
            var categoryArticles = db.Categories.Include("Articles")
                                .Single(c => c.CategoryId == id);

            return View(categoryArticles);
        }

        public ActionResult CreateCategory()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Category", new { id = category.CategoryId });
            }

            return View(category);
        }

        public ActionResult Article(int id)
        {
            var article = db.Articles.Include("Comments")
                        .Single(c => c.ArticleId == id);

            return View(article);
        }

        public ActionResult CreateArticle()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

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

        public ActionResult EditArticle(int id)
        {
            var article = db.Articles.Single(c => c.ArticleId == id);

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", article.CategoryId);
            return View(article);
        }

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

        public ActionResult DeleteArticle(int id)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("DeleteArticle")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Category", new { id = article.CategoryId });
        }

        [HttpPost]
        public ActionResult AddComment(int articleId, Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CommentDate = DateTime.Now;
                comment.ArticleId = articleId;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Article", new { id = comment.ArticleId });
            }

            return View(comment.Article);
        }
    }
}
