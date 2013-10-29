﻿using System.ComponentModel.DataAnnotations;

namespace MVCBlog.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}