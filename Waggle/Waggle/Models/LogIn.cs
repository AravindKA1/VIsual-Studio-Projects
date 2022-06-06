﻿using System.ComponentModel.DataAnnotations;

namespace Waggle.Models
{
    public class LogIn
    {
        [Required]
        [Display(Name ="User Name")]
        public string  UserName { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}
