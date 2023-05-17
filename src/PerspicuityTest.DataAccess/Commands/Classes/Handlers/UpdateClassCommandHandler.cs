using AutoMapper;
using MediatR;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.DataAccess.Classes.Writers;
using PerspicuityTest.Core.Dtos;
using PerspicuityTest.Core.Utilities.Exceptions;

namespace PerspicuityTest.Core.Commands.Classes.Handlers
{
    internal class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, Class>
    {
        private readonly IMapper _mapper;

        private readonly IUpdateClassWriter _updateClassWriter;

        private readonly IGetClassByIdReader _getClassByIdReader;

        public UpdateClassCommandHandler(IMapper mapper, IUpdateClassWriter updateClassWriter, IGetClassByIdReader getClassByIdReader)
        {
            _mapper = mapper;
            _updateClassWriter = updateClassWriter;
            _getClassByIdReader = getClassByIdReader;
        }

        public async Task<Class> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            if (!request.Class.Id.HasValue) throw new ArgumentNullException(nameof(request.Class.Id));
            var existingClass = await _getClassByIdReader.GetById(request.Class.Id.Value);

            if (existingClass == null) throw new NotFoundException($"Cannot find class with id '{request.Class.Id}'");

            existingClass = _mapper.Map<Database.Models.Class>(request.Class);
            await _updateClassWriter.Update(existingClass);

            return request.Class;
        }
    }
}
