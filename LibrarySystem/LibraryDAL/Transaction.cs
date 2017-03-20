using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
   public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime DateOfIssue { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int BookId { get; set; }
        public virtual Catalog Catalog { get; set; }

        public int LibraryId { get; set; }
        public virtual Library Library { get; set; }


    }
}
