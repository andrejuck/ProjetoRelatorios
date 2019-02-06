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
        Task<T> Get(int id);
        /// <summary>
        /// Get all registries from database
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> GetAll();        
        Task<bool> Delete(int id);
        Task<bool> Create(T model);
        Task<bool> Update(T model);
    }
}
