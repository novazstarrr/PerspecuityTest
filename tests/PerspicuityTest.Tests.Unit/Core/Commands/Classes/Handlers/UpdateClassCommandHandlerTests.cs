using Moq;
using PerspicuityTest.Core.Commands.Classes;
using PerspicuityTest.Core.Commands.Classes.Handlers;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.DataAccess.Classes.Writers;
using PerspicuityTest.Core.Dtos;
using PerspicuityTest.Core.Utilities.Exceptions;
using PerspicuityTest.Database.Models;
using PerspicuityTest.Tests.Unit.Core.Mappers._TestUtils_;
using Class = PerspicuityTest.Core.Dtos.Class;

namespace PerspicuityTest.Tests.Unit.Core.Commands.Classes.Handlers
{
    // TODO - Remove this
    // MOQ allows us to create mocks
    //public class MockUpdateClassWriter : IUpdateClassWriter
    //{
    //    public Class Response { get; set; }

    //    public Task<Class> Update(Class @class)
    //    {
    //        return Response;
    //    }
    //}

    public class UpdateClassCommandHandlerTests
    {
        private readonly UpdateClassCommandHandler _updateClassCommandHandler;

        private readonly Mock<IUpdateClassWriter> _updateClassWriterMock;

        private readonly Mock<IGetClassByIdReader> _getClassByIdReaderMock;

        public UpdateClassCommandHandlerTests()
        {
            var mapper = AutoMapperTestUtils.BuildCoreMapper();
            _updateClassWriterMock = new Mock<IUpdateClassWriter>();
            _getClassByIdReaderMock = new Mock<IGetClassByIdReader>();

            _updateClassCommandHandler = new UpdateClassCommandHandler(mapper, _updateClassWriterMock.Object, _getClassByIdReaderMock.Object);
        }

        [Fact]
        public void Handle_throws_ArgumentNullException_for_null_ClassId()
        {
            var classDto = new Class(null, "Name", DateTime.Now, DateTime.Now);

            Assert.ThrowsAsync<ArgumentNullException>(() => _updateClassCommandHandler.Handle(new UpdateClassCommand(classDto), new CancellationToken()));
        }

        [Fact]
        public void Handle_throws_NotFoundException_for_client_id_that_does_not_exist()
        {
            var classDto = new Class(Guid.NewGuid(), "Name", DateTime.Now, DateTime.Now);

            _getClassByIdReaderMock.Setup(x => x.GetById(classDto.Id!.Value)).ReturnsAsync((Database.Models.Class?)null);

            Assert.ThrowsAsync<NotFoundException>(() => _updateClassCommandHandler.Handle(new UpdateClassCommand(classDto), new CancellationToken()));
        }

        [Fact]
        public async Task Handle_returns_a_class_for_a_valid_id()
        {
            var classDto = new Class(Guid.NewGuid(), "Name", DateTime.Now, DateTime.Now);

            _getClassByIdReaderMock.Setup(x => x.GetById(classDto.Id!.Value)).ReturnsAsync(new Database.Models.Class
            {
                Id = classDto.Id!.Value,
                Name = classDto.Name,
                Start = classDto.Start,
                End = classDto.End
            });

            var response = await _updateClassCommandHandler.Handle(new UpdateClassCommand(classDto), new CancellationToken());

            Assert.NotNull(response);
            Assert.Equal(classDto.Id, response.Id);
            Assert.Equal(classDto.Name, response.Name);
            Assert.Equal(classDto.Start, response.Start);
            Assert.Equal(classDto.End, response.End);
        }
    }
}
