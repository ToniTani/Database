﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp1.Models
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(decimal? amount, DateTime? timeStamp)
        {
            Amount = amount;
            TimeStamp = timeStamp;
        }

        public long Id { get; set; }
        [Column("IBAN", TypeName = "nchar(20)")]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeStamp { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("Transaction")]
        public Account IbanNavigation { get; set; }

        //Tostring override
        public override string ToString()
        {
            return $"{Amount}, {TimeStamp}";
        }
    }
}