using System;
using System.Collections.Generic;
using System.Linq;
using BankApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp1.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        private readonly BankAppContext _context = new BankAppContext();

        //Print accounts
        public List<Account> Read()
        {
            var accounts = _context.Account.ToListAsync().Result;
            return accounts;
        }

        //Find account by id
        public Account GetAccountById(string iban)
        {
            var account = _context.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        //Create a new account
        public void CreateAccount(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        //Delete an account
        public void DeleteAccount(string iban)
        {
            var delAccount = _context.Account.FirstOrDefault(a => a.Iban == iban);
            if (delAccount != null)
                _context.Account.Remove(delAccount);
            _context.SaveChanges();
        }

        //Creating transactions
        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                _context.Transaction.Add(transaction);
                //searching new account and update
                var account = GetAccountById(transaction.Iban);
                //calculating new value
                account.Balance += transaction.Amount;

                //update Account table
                _context.Account.Update(account);
                //saving changes
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

