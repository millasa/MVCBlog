using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public int UserID { get; set; }
        [Required]
        public int ArticleID { get; set; }

        public DateTime CommentDate { get; set; }
        public string CommentText { get; set; }

        public virtual Article Article { get; set; }
        public virtual User Author { get; set; }
    }
}