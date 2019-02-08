using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class Bank : BaseModel
    {
        //TODO - CRUD METHODS
        public string Name { get; set; }
        public User User { get; set; }
        public IList<BankAccount> BankAccounts { get; set; }
    }
}