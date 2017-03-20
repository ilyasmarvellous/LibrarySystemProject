using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
   public class Catalog
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
