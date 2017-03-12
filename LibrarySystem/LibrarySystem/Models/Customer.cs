using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public int LibraryId { get; set; }
        [ForeignKey ("LibraryId")]
        public virtual Library Library { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Catalog Catalog  { get; set; }


        public virtual ICollection<Transaction> Transactions  { get; set; }
        
    }
}