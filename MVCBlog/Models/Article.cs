using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string ArticleName { get; set; }
        public string ArticleText { get; set; }
    }
}