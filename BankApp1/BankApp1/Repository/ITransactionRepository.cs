using System;
using System.Collections.Generic;
using System.Text;
using BankApp1.Models;

namespace BankApp1.Repository
{
    interface ITransactionRepository
    {
        List<Transaction> Read();
        //Transaction GetTransactionById(string iban);

    }
}