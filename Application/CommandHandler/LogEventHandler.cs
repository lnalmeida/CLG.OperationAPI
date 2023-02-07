using MediatR;
using CLG.OperationsAPI.Application.Notifications;

namespace CLG.OperationsAPI.Application.CommandHandler
{
    public class LogEventHandler : INotificationHandler<CreateOpNotification>, INotificationHandler<UpdateOpNotification>, INotificationHandler<DeleteOpNotification>
    {
        public Task Handle(CreateOpNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                string typeOp = "Crédito";
                if (notification.TypeOp == 0)
                {
                    typeOp = "Débito";
                }
                Console.WriteLine($"Add : {notification.Id} - {notification.DateOp} - {typeOp} - {notification.DescriptionOp} - {notification.ValueOp}");
            });
        }

        public Task Handle(DeleteOpNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Removed: {notification.Id}");
            });
        }

        public Task Handle(UpdateOpNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                string typeOp = "Crédito";
                if (notification.TypeOp == 0)
                {
                    typeOp = "Débito";
                }
                Console.WriteLine($"Edited: {notification.Id} - {notification.DateOp} - {typeOp} - {notification.DescriptionOp} - {notification.ValueOp}");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERROR: '{notification.Error} \n {notification.ErrorStack}'");
            });
        }
    }
}