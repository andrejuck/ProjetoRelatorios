using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class Expense : BaseModel
    {
        public User User { get; set; }
        public ChartAccount ChartAccount { get; set; }
    }
}
