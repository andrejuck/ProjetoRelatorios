using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmissorPedidos.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Usuario class
    public class UsuarioIdentity : IdentityUser
    {
        [PersonalData]
        public string Nome { get; set; }
    }
}
