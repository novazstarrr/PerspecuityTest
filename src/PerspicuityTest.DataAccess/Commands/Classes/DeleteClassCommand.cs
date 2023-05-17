using MediatR;

namespace PerspicuityTest.Core.Commands.Classes
{
    public record DeleteClassCommand(Guid ClassId) : IRequest
    {
    }
}
