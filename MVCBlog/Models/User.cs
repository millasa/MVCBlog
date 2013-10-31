using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBlog.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [InverseProperty("User")]
        public List<Article> Articles { get; set; }
        [InverseProperty("User")]
        public List<Comment> Comments { get; set; }
    }
}