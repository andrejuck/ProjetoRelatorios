using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class Expense : BaseModel
    {
        public string Description { get; set; }
        public string Observation { get; set; }
        public decimal ExpenseValue { get; set; }
        public decimal PaidValue { get; set; }
        public decimal PenaltyValue { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpenseDate { get; set; }
        public BankAccount BankAccount { get; set; }
        public PaymentType PaymentType { get; set; }
        public User User { get; set; }
        public ChartAccount ChartAccount { get; set; }
    }
}
