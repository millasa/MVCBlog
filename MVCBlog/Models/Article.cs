using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public string ArticleName { get; set; }
        [Required]
        public string ArticleText { get; set; }

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int UserId { get; set; }

        [InverseProperty("Article")]
        public List<Comment> Comments { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}