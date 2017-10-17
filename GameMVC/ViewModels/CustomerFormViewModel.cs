using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMVC.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<SignatureCustomer> SignatureCustomer { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Editar Cliente";

                return "Novo Cliente";
            }
        }
    }
}