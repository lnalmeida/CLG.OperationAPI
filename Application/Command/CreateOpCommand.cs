using MediatR;

namespace CLG.OperationsAPI.Application.Command
{
    public class CreateOpCommand : IRequest<string>
    {
        public string DescriptionOp { get; set; }
        public DateTime DateOp { get; set; }
        public double ValueOp { get; set; }
        public int TypeOp { get; set; }
        public bool IsDebit => TypeOp == 0;
    }
}