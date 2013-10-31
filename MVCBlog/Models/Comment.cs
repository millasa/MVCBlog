using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public int UserId { get; set; }
        [Required]
        public int ArticleId { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }
        [Required]
        public string CommentText { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}