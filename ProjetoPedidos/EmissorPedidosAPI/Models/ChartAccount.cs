using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class ChartAccount : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
