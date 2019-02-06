using EmissorPedidosAPI.Models;

namespace EmissorPedidosAPI.Repositories.Interfaces
{
    public interface IAuditRepository<T> where T : BaseModel
    {
        bool Create(T audit, string changes);
    }
}