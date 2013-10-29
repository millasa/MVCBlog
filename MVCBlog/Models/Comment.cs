using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int ArticleID { get; set; }
        public string UserID { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }
    }
}