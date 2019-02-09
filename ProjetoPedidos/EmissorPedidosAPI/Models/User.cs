using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class User : BaseModel
    {        
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Activated { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<CompanyAudit> CompaniesAudit { get; set; }
        public IList<ChartAccount> ChartAccounts { get; set; }
        public IList<Expense> Expenses { get; set; }
        public IList<BankAccount> BankAccounts { get; set; }
        public IList<Bank> Banks { get; set; }
        public IList<Income> Incomes { get; set; }
        public virtual Company Company { get; set; }      
        public string Token { get; set; }

    }
}