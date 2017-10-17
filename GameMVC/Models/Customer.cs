using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name= "Nome")]
        public string Name { get; set; }

        [Display(Name = "VIP")]
        public bool isPremium { get; set; }

        [Display(Name = "Tipo de Assinatura")]
        public SignatureCustomer SignatureCustomer { get; set; }
        
        public byte SignatureCustomerId { get; set; }

    }
}