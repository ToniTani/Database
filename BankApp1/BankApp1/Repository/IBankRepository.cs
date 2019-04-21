using System.Collections.Generic;
using BankApp1.Models;

namespace BankApp1.Repository
{
    internal interface IBankRepository
    {
            List<Bank> GetTransactionsFromBankCustomersAccounts();
            Bank GetBankById(long id);
            void Create(Bank bank);
            void Update(Bank bank);
            void Delete(int id);
        }
    }
