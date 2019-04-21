using System.Collections.Generic;
using BankApp1.Models;

namespace BankApp1.Repository
{
    interface IAccountRepository
    {
        List<Account> Read();
        Account GetAccountById(string iban);
        void CreateAccount(Account account);
        void DeleteAccount(string iban);
        void CreateTransaction(Transaction transaction);
    }
}