﻿using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class EstadoRepository : BaseRepository, IEstadoRepository
    {
        public EstadoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IList<Estado> CarregarTodosEstados()
        {
            var listEstados = _context.Estados.ToList();

            if (listEstados.Count > 0)
                return listEstados;

            throw new Exception("Não foi possível carregar os estados");
        }

        public Estado CarregarEstadoPorId(int id)
        {
            try
            {
                return _context.Estados.Where(w => w.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
