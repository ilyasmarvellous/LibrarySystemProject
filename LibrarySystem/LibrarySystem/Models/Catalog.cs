using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibrarySystem.Models
{
    public class Catalog
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int price { get; set; }
        public int LibraryId { get; set; }
        [ForeignKey("LibraryId")]
        public virtual Library Library { get; set; }

        public virtual ICollection<Transaction> Transactions  { get; set; }

    }
}