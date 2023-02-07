using MediatR;

namespace CLG.OperationsAPI.Application.Command
{
    public class DeleteOpCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}