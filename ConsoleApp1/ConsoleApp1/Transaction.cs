using System;

namespace classes
{
    class Transaction
    {
        // 建立存款和提款
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note) 
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }
}
