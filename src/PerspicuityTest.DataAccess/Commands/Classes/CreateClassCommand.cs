using MediatR;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Commands.Classes
{
    public record CreateClassCommand(Class Class) : IRequest<Class>
    {
    }
}
