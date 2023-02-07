using CLG.OperationsAPI.Application.Context;
using CLG.OperationsAPI.Application.Entity;
using Microsoft.EntityFrameworkCore;

namespace CLG.OperationsAPI.Application.Repository
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly OperationContext _dbContext;

        public OperationRepository(OperationContext context)
        {
            this._dbContext = context;
        }
        public async Task<IEnumerable<Operation>> GetAllOps()
        {
            return await _dbContext.Operations.ToListAsync();
        }
        public async Task<Operation> GetOp(int id)
        {
            return await _dbContext.Operations.FindAsync(id);
        }
        public async Task<Operation> CreateOp(Operation op)
        {
            await _dbContext.Operations.AddAsync(op);
            await _dbContext.SaveChangesAsync();
            return op;
        }
        public async Task UpdateOp(Operation op)
        {
            _dbContext.Operations.Update(op);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteOp(int id)
        {
            var opToDelete = await _dbContext.Operations.FindAsync(id);
            _dbContext.Operations.Remove(opToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}