using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibraryDAL
{
    public class CustomerRepo
    {
        private LibraryContext context;
        public CustomerRepo()
        {
            context = new LibraryContext();
        }
        //CRUD Operations
        
        public Customer GetByCustomerId(int CustomerId)
        {
           Customer cust =context.Customers.Where(s => s.CustomerId == CustomerId).FirstOrDefault();
            return cust;
        }

        public void InsertCustomer(Customer cust)
        {
            context.Customers.Add(cust);
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer cust)
        {
           Customer update =context.Customers.Where(p => p.CustomerId == cust.CustomerId).FirstOrDefault();
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer cust)
        {
            context.Customers.Remove(cust);
            context.SaveChanges();
        }
    }
}
