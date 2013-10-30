using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }

        public string ArticleName { get; set; }
        public string ArticleText { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int AuthorID { get; set; }

        [InverseProperty("Article")]
        public List<Comment> Comments { get; set; }

        public virtual Category Category { get; set; }
        public virtual User Author { get; set; }
    }
}