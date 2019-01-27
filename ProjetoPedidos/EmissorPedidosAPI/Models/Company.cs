using System;
using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class Company : BaseModel
    {        
        public string SocialName { get; set; }
        public string FantasyName { get; set; }
        public string Subscription { get; set; }
        public string StateSubscription { get; set; }        
        public string Email { get; set; }
        public bool Activated { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Address> Addresses {get; set;}
        public IList<User> Users {get; set;}
    }
}