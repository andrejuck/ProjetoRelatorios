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
        public IList<Phone> Phone { get; set; }
        public IList<Address> Address {get; set;}
        public IList<User> Users {get; set;}
    }
}