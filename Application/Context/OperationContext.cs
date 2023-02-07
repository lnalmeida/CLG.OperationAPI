using MediatR;
using CLG.OperationsAPI.Application.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;


namespace CLG.OperationsAPI.Application.Context
{
    public class OperationContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public OperationContext(DbContextOptions<OperationContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db_movements.db");
        }
    }
}