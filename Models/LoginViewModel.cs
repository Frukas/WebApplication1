﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]  
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; } = true;
    }
}
