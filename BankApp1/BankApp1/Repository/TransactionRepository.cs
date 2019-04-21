using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BankApp1.Models;

namespace BankApp1.Repository
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankAppContext _context = new BankAppContext();

        //Print Transactions
        public List<Transaction> Read()
        {
            List<Transaction> transactions = _context.Transaction.ToListAsync().Result;
            return transactions;
        }


        ////Find specific transaction
        public Transaction GetTransactionById(int id)
        {
            var transaction = _context.Transaction.FirstOrDefault(t => t.Id == id);
            return transaction;
        }
    }
}
