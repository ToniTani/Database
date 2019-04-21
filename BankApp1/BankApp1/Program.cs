using System;
using BankApp1.Models;
using BankApp1.Repository;

namespace BankApp1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Print();
            CreateBank();
            UpdateBank();
            DeleteBank();
            GetBankById();
            DeleteAccount();
            GetAccountByIban();
            CreateCustomer();
            UpdateCustomer();
            GetCustomerById();
            GetTransactionById();
            Console.WriteLine("\n<Enter> End program!");
            Console.ReadLine();

        }

        private static void DeleteAccount()
        {
            var accountRepository = new AccountRepository();
            accountRepository.DeleteAccount("FI4925678945");
        }

        private static void CreateCustomer()
        {
            var customerRepository = new CustomerRepository();
            var c1 = new Customer("Onni", "Unto");
            var c2 = new Customer("Musta", "Kaapu");
            customerRepository.CreateCustomer(c1);
            customerRepository.CreateCustomer(c2);
        }

        private static void UpdateCustomer()
        {
            var customerRepository = new CustomerRepository();
            Customer updateCustomer = customerRepository.GetCustomerById(3);
            updateCustomer.FirstName = "Fred";
            updateCustomer.LastName = "Kruger";
            customerRepository.UpdateCustomer(updateCustomer, 3);
        }

        public static void DeleteCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteCustomer(5);
        }
        static void GetCustomerById()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.GetCustomerById(2);
        }

        private static void CreateBank()
        {
            var bankRepository = new BankRepository();
            var b = new Bank("Jap", "JIPONi");
            var b2 = new Bank("OP", "NIPPOn");
            var b3 = new Bank(" Nordea", "JAPPOn");
            bankRepository.Create(b2);
            bankRepository.Create(b);
            bankRepository.Create(b3);
        }
        static void UpdateBank()
        {
            var bankRepository = new BankRepository();
            var updateBank = bankRepository.GetBankById(2);
            updateBank.Name = "Persauki Pankki";
            updateBank.Bic = "RAPFI";
            bankRepository.Update(updateBank);
        }

        private static void DeleteBank()
        {
            var bankRepository = new BankRepository();
            bankRepository.Delete(4);
        }
        static void GetBankById()
        {
            var bankRepository = new BankRepository();
            bankRepository.GetBankById(2);
        }

        private static void CreateTransaction()
        {
            AccountRepository accountRepository = new AccountRepository();

            TransactionRepository transactionRepository = new TransactionRepository();
            Transaction transaction = new Transaction
            {
                Iban = "FI49123456789",
                Amount = 3000,
                TimeStamp = DateTime.Today
            };
            accountRepository.CreateTransaction(transaction);
        }
        static void GetTransactionById()
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            transactionRepository.GetTransactionById(4);
        }

        private static void GetAccountByIban()
        {
            AccountRepository accountRepository = new AccountRepository();
            accountRepository.GetAccountById("FI497894563");
        }
        static void Print()
        {
            BankRepository bankRepository = new BankRepository();

            var bankCustomers = bankRepository.GetTransactionsFromBankCustomersAccounts();

            foreach (var bC in bankCustomers)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn}");
                        }
                    }
                }
            }
        }
    }
}
