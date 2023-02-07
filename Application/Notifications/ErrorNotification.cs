using MediatR;

namespace CLG.OperationsAPI.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Error { get; set; }
        public string ErrorStack { get; set; }
    }
}