using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibraryDAL
{
    class TransactionRepo
    {
        private LibraryContext context;
        public TransactionRepo()
        {
            context = new LibraryContext();
        }
        //CRUD Operations

        public Transaction GetByTransactionId(int TransactionId)
        {
            Transaction transaction = context.Transactions.Where(s => s.TransactionId == TransactionId).FirstOrDefault();
            return transaction;
        }

        public void InsertTransaction(Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            Transaction update = context.Transactions.Where(p => p.TransactionId == transaction.TransactionId).FirstOrDefault();
            context.SaveChanges();
        }

        public void DeleteTransaction(Transaction transaction)
        {
            context.Transactions.Remove(transaction);
            context.SaveChanges();
        }
    }
}
