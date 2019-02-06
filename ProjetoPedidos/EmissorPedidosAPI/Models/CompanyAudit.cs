using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Models
{
    public class CompanyAudit : BaseModel
    {
        public Company Company { get; set; }
        public User User { get; set; }
        public string Change { get; set; }
        public DateTime ChangeDate { get; set; }
        public string OldSocialName { get; set; }
        public string OldFantasyName { get; set; }
        public string OldSubscription { get; set; }
        public string OldStateSubscription { get; set; }
        public string OldEmail { get; set; }
        public bool OldActivated { get; set; }
        public string NewSocialName { get; set; }
        public string NewFantasyName { get; set; }
        public string NewSubscription { get; set; }
        public string NewStateSubscription { get; set; }
        public string NewEmail { get; set; }
        public bool NewActivated { get; set; }        
    }
}
