using CLG.OperationsAPI.Application.Entity;

namespace CLG.OperationsAPI.Application.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllOps();
        Task<T> GetOp(int id);
        Task<Operation> CreateOp(T op);
        Task UpdateOp(T op);
        Task DeleteOp(int id);
    }
}