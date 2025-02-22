﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiWindowsForm
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string? ToString()
        {
            return $"{CustomerId} -  {Name} - {Email} -{PhoneNumber}";
        }
    }
}
