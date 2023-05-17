using AutoMapper;
using MediatR;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Queries.Classes.Handlers
{
    internal class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<Class>>
    {
        private readonly IMapper _mapper;

        private readonly IGetAllClassesReader _getAllClassesReader;

        public GetAllClassesQueryHandler(IMapper mapper, IGetAllClassesReader getAllClassesReader)
        {
            _mapper = mapper;
            _getAllClassesReader = getAllClassesReader;
        }

        public async Task<IEnumerable<Class>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            var existingClasses = await _getAllClassesReader.GetAll();

            return _mapper.Map<IEnumerable<Class>>(existingClasses);
        }
    }
}
