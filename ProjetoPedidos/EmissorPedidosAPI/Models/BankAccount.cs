using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class BankAccount : BaseModel
    {
        public string Description { get; set; }
        public int AccountNumber { get; set; }
        public byte AccountDigit { get; set; } 
        public int BankAgency { get; set; }
        public byte BankAgencyDigit { get; set; }
        public Bank Bank { get; set; }
        public User User { get; set; }
        public IList<Expense> Expenses { get; set; }
        public IList<Income> Incomes { get; set; }
    }
}