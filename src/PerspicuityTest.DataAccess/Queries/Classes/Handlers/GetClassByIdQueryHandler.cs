using AutoMapper;
using MediatR;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Queries.Classes.Handlers
{
    internal class GetClassByIdQueryHandler : IRequestHandler<GetClassByIdQuery, Class?>
    {
        private readonly IMapper _mapper;

        private readonly IGetClassByIdReader _getClassByIdReader;

        public GetClassByIdQueryHandler(IMapper mapper, IGetClassByIdReader getClassByIdReader)
        {
            _mapper = mapper;
            _getClassByIdReader = getClassByIdReader;
        }

        public async Task<Class?> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            var existingClass = await _getClassByIdReader.GetById(request.ClassId);

            if (existingClass == null) return null;

            return _mapper.Map<Class>(existingClass);
        }
    }
}
