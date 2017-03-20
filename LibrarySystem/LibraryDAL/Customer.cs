﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
   
        [Table("Customers")]
        public class Customer
        {
            [Key]
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public double PhoneNumber { get; set; }
            public string Address { get; set; }

            public virtual ICollection<Transaction> Transactions { get; set; }

        }
    }
