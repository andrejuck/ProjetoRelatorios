﻿using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Interfaces.Repositories
{
    public interface IPaisRepository
    {
        IList<Pais> CarregarTodosPaises();
    }
}
