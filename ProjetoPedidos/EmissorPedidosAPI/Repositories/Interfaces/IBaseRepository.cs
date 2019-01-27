using EmissorPedidosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories.Interfaces
{
    /// <summary>
    /// Generic interface to padronize CRUD methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseModel
    {
        /// <summary>
        /// Get data from an id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Get all registries from database
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();        
        bool Delete(int id);
        bool Create(T model);
        bool Update(T model);
    }
}
