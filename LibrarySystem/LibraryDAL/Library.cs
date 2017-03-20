using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
   public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double PhoneNumber { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
