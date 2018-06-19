using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingSolution.Data.Models
{
    public class RegisterForm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int[] Sector { get; set; }
        [Required]
        public bool Agree { get; set; }
    }
}