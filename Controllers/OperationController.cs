using MediatR;
using Microsoft.AspNetCore.Mvc;
using CLG.OperationsAPI.Application.Command;
using CLG.OperationsAPI.Application.Entity;
using CLG.OperationsAPI.Application.Repository;
using CLG.OperationsAPI.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace CLG.OperationsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Operation> _repository;
        private readonly OperationContext _dbContext;
        private double operation;

        public OperationController(IMediator mediator, IRepository<Operation> repository, OperationContext _dbContext)
        {
            this._mediator = mediator;
            this._repository = repository;
            this._dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOps()
        {
            return Ok(await _dbContext.Operations.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOp(int id)
        {
            return Ok(await _dbContext.Operations.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOp(CreateOpCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOp(UpdateOpCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOp(int id)
        {
            var obj = new DeleteOpCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }

        [HttpGet("balance")]
        public ActionResult<double> GetTodayBalance()
        {
            var todayOperations = _dbContext.Operations.Where(operation => operation.DateOp.Date == DateTime.Today.Date);
            var todayBalance = todayOperations.Sum(operation => operation.ValueOp);
            return Math.Round(todayBalance, 2);
        }
    }
}