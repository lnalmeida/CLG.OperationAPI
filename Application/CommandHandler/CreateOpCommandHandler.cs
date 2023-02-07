using MediatR;
using CLG.OperationsAPI.Application.Command;
using CLG.OperationsAPI.Application.Entity;
using CLG.OperationsAPI.Application.Notifications;
using CLG.OperationsAPI.Application.Repository;

namespace CLG.OperationsAPI.Application.CommandHandler
{
    public class CreateOpCommandHandler : IRequestHandler<CreateOpCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Operation> _repository;

        public CreateOpCommandHandler(IMediator mediator, IRepository<Operation> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(CreateOpCommand request, CancellationToken cancellationToken)
        {
            var operation = new Operation
            {
                DescriptionOp = request.DescriptionOp,
                DateOp = request.DateOp,
                ValueOp = request.IsDebit ? -request.ValueOp : request.ValueOp,
                TypeOp = request.TypeOp
            };

            try
            {
                operation = await _repository.CreateOp(operation);

                await _mediator.Publish(new CreateOpNotification
                {
                    Id = operation.Id,
                    DescriptionOp = request.DescriptionOp,
                    DateOp = request.DateOp,
                    ValueOp = request.ValueOp,
                    TypeOp = request.TypeOp
                });

                return await Task.FromResult("Success");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new CreateOpNotification
                {
                    DescriptionOp = request.DescriptionOp,
                    DateOp = request.DateOp,
                    ValueOp = request.ValueOp,
                    TypeOp = request.TypeOp
                });
                await _mediator.Publish(new ErrorNotification { Error = ex.Message, ErrorStack = ex.StackTrace });
                return await Task.FromResult("An Error occurred");
            }
        }
    }
}