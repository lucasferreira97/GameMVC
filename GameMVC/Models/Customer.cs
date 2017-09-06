﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isPremium { get; set; }

        public SignatureCustomer SignatureCustomer { get; set; }
        
        public byte SignatureCustomerId { get; set; }

    }
}