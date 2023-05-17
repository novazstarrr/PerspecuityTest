using MediatR;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Queries.Classes
{
    public record GetClassByIdQuery(Guid ClassId) : IRequest<Class?>
    {
    }
}
