using MediatR;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.DataAccess.Classes.Writers;
using PerspicuityTest.Core.Utilities.Exceptions;

namespace PerspicuityTest.Core.Commands.Classes.Handlers
{
    internal class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand>
    {
        private readonly IGetClassByIdReader _getClassByIdReader;

        private readonly IDeleteClassWriter _deleteClassWriter;

        public DeleteClassCommandHandler(IGetClassByIdReader getClassByIdReader, IDeleteClassWriter deleteClassWriter)
        {
            _getClassByIdReader = getClassByIdReader;
            _deleteClassWriter = deleteClassWriter;
        }

        public async Task Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var existingClass = await _getClassByIdReader.GetById(request.ClassId);
            if (existingClass == null) throw new NotFoundException($"Cannot delete class as not class with id '{request.ClassId}' found");

            await _deleteClassWriter.Delete(request.ClassId);
        }
    }
}
