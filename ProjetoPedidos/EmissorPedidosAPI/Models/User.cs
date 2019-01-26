using System.Collections.Generic;

namespace EmissorPedidosAPI.Models
{
    public class User : BaseModel
    {        
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IList<Phone> Phones { get; set; }
        public virtual Company Company { get; set; }      

    }
}