using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class Income : BaseModel
    {
        public string Description { get; set; }
        public string Observation { get; set; }
        public decimal IncomeValue { get; set; }
        public decimal PaidValue { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public User User { get; set; }
        public ChartAccount ChartAccount { get; set; }
        public BankAccount BankAccount { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
