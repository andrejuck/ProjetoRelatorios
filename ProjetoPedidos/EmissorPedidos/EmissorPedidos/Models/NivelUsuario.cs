﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Models
{
    public class NivelUsuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; }     
        
        public List<Usuarios> Usuarios { get; set; }
    }
}
