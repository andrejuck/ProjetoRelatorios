using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class PaymentType : BaseModel
    {
        public string Description { get; set; }
        public IList<Expense> Expenses { get; set; }
        public IList<Income> Incomes { get; set; }
    }
}
