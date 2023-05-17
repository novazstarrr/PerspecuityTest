using MediatR;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Commands.Classes
{
    public record UpdateClassCommand(Class Class) : IRequest<Class>
    {
    }
}
