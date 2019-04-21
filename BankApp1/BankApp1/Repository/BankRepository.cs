using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BankApp1.Models;
using System.Linq;


namespace BankApp1.Repository
{
    internal class BankRepository : IBankRepository
    {
        private readonly BankAppContext _context = new BankAppContext();

        //Tulosta Pankit
        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            var banks = _context.Bank
                .Include(b => b.Customer)
                .Include(b => b.Account)
                .Include(b => b.Account).ThenInclude(a => a.Transaction)
                .ToListAsync().Result;
            return banks;
        }

        //Etsi tietty pankki
        public Bank GetBankById(long id)
        {
            var bank = _context.Bank.FirstOrDefault(b => b.Id == id);
            return bank;
        }

        //Lisää pankki
        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        //Update Bank
        public void Update(Bank bank)
        {
            var updateBank = GetBankById(bank.Id);
            if (updateBank != null)
            {
                updateBank.Name = bank.Name;
                updateBank.Bic = bank.Bic;
                _context.Bank.Update(bank);
            }
            _context.SaveChanges();
        }

        //Delete Bank
        public void Delete(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null)
                _context.Bank.Remove(delBank);
            _context.SaveChanges();
        }
    }
}
