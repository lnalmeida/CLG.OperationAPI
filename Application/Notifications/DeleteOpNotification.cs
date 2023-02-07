using MediatR;

namespace CLG.OperationsAPI.Application.Notifications
{
    public class DeleteOpNotification : INotification
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}