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
        // GET: /Blog/BrowseArticlesByCategory/<id>

        public ActionResult BrowseArticlesByCategory(int id)
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

    }
}
