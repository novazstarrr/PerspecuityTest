using AutoMapper;
using MediatR;
using PerspicuityTest.Core.DataAccess.Classes.Writers;
using PerspicuityTest.Core.Dtos;

namespace PerspicuityTest.Core.Commands.Classes.Handlers
{
    internal class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, Class>
    {
        private readonly IMapper _mapper;
        private readonly ICreateClassWriter _createClassWriter;

        public CreateClassCommandHandler(ICreateClassWriter createClassWriter, IMapper mapper)
        {
            _createClassWriter = createClassWriter;
            _mapper = mapper;
        }

        public async Task<Class> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var classModel = _mapper.Map<Database.Models.Class>(request.Class);
            classModel = await _createClassWriter.Create(classModel);

            return _mapper.Map<Class>(classModel);
        }
    }
}
