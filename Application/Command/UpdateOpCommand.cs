using MediatR;


namespace CLG.OperationsAPI.Application.Command
{
    public class UpdateOpCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string DescriptionOp { get; set; }
        public DateTime DateOp { get; set; }
        public double ValueOp { get; set; }
        public int TypeOp { get; set; }
    }
}