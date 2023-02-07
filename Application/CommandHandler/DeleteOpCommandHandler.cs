using MediatR;
using CLG.OperationsAPI.Application.Command;
using CLG.OperationsAPI.Application.Entity;
using CLG.OperationsAPI.Application.Notifications;
using CLG.OperationsAPI.Application.Repository;

namespace CLG.OperationsAPI.Application.CommandHandler
{
    public class DeleteOpCommandHandler : IRequestHandler<DeleteOpCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Operation> _repository;
        public DeleteOpCommandHandler(IMediator mediator, IRepository<Operation> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(DeleteOpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteOp(request.Id);

                await _mediator.Publish(new DeleteOpNotification { Id = request.Id });

                return await Task.FromResult("Success");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new DeleteOpNotification { Id = request.Id });
                await _mediator.Publish(new ErrorNotification { Error = ex.Message, ErrorStack = ex.StackTrace });
                return await Task.FromResult("An Error occurred");
            }
        }
    }
}