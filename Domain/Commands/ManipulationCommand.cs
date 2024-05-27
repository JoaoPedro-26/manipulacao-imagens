using MediatR;
using ImageManipulation.Api.Domain.Response;

namespace ImageManipulation.Api.Domain.Commands
{
    public class ManipulationCommand : IRequest<ManipulationCommandResponse>
    {
        public string image { get; set; }
        public string format { get; set; }
    }
}
