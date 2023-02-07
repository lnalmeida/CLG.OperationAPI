using MediatR;
using CLG.OperationsAPI.Application.Command;
using CLG.OperationsAPI.Application.Entity;
using CLG.OperationsAPI.Application.Notifications;
using CLG.OperationsAPI.Application.Repository;

namespace CLG.OperationsAPI.Application.CommandHandler
{
    public class UpdateOpCommandHandler : IRequestHandler<UpdateOpCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Operation> _repository;

        public UpdateOpCommandHandler(IMediator mediator, IRepository<Operation> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(UpdateOpCommand request, CancellationToken cancellationToken)
        {
            var operation = new Operation
            {
                Id = request.Id,
                DescriptionOp = request.DescriptionOp,
                DateOp = request.DateOp,
                ValueOp = request.ValueOp,
                TypeOp = request.TypeOp
            };

            try
            {
                await _repository.UpdateOp(operation);

                await _mediator.Publish(new UpdateOpNotification
                {
                    Id = request.Id,
                    DescriptionOp = request.DescriptionOp,
                    DateOp = request.DateOp,
                    ValueOp = request.ValueOp,
                    TypeOp = request.TypeOp
                });

                return await Task.FromResult("Success");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new UpdateOpNotification
                {
                    Id = request.Id,
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