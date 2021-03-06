﻿using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> SalvarUsuarioAsync(Usuario user);
        Usuario CarregarUsuarioLogado(string identityId);
        Usuario CarregarUsuarioPorId(int id);
    }
}
