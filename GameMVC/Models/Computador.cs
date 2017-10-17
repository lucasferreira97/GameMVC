using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameMVC.Models
{
    public class Computador
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

    }
}