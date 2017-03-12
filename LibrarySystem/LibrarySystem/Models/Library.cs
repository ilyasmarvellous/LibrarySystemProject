using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double PhoneNumber { get; set; }
        public virtual ICollection<Catalog> Catalogs {get;set;}
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }


    }
}