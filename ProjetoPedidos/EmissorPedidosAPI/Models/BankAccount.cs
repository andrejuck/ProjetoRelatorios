using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class BankAccount : BaseModel
    {
        public string Description { get; set; }
        public int AccountNumber { get; set; }
        public int AccountDigit { get; set; }
        public int BankAgency { get; set; }
        public int BankAgencyDigit { get; set; }
        public Bank Bank { get; set; }
        public User User { get; set; }
        public IList<Expense> Expenses { get; set; }
    }
}