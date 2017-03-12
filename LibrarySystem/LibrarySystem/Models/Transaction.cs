using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Catalog Catalog { get; set; }
        public int LibraryId { get; set; }

        [ForeignKey("LibraryId")]
        public virtual Library Library { get; set; }

     
    }
}