using MediatR;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Queries.Classes
{
    public record GetAllClassesQuery() : IRequest<IEnumerable<Class>>
    {
    }
}
