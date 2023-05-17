using AutoMapper;
using PerspicuityTest.Core.Dtos;
using PerspicuityTest.Core.Mappers;
using PerspicuityTest.Tests.Unit.Core.Mappers._TestUtils_;

namespace PerspicuityTest.Tests.Unit.Core.Mappers
{
    public class ClassesMapperRegistrarTests
    {
        private readonly IMapper _mapper;

        public ClassesMapperRegistrarTests()
        {
            _mapper = AutoMapperTestUtils.BuildCoreMapper();
        }

        [Fact]
        public void Mapping_from_Class_database_model_to_Class_dto_maps_properties_correctly()
        {
            var model = new Database.Models.Class
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1)
            };

            var dto = _mapper.Map<Class>(model);

            Assert.NotNull(dto);
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.Name, dto.Name);
            Assert.Equal(model.Start, dto.Start);
            Assert.Equal(model.End, dto.End);
        }

        // TODO - Write a test for Class DTO to Model (inverse of the above)
    }
}
