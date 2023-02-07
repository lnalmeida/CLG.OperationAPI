using MediatR;

namespace CLG.OperationsAPI.Application.Notifications
{
    public class UpdateOpNotification : INotification
    {
        public int Id { get; set; }
        public string DescriptionOp { get; set; }
        public DateTime DateOp { get; set; }
        public double ValueOp { get; set; }
        public int TypeOp { get; set; }
        public bool IsCompleted { get; set; }
    }
}