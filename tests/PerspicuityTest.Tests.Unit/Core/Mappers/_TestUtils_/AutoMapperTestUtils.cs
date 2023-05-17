using AutoMapper;
using PerspicuityTest.Core.Mappers;

namespace PerspicuityTest.Tests.Unit.Core.Mappers._TestUtils_
{
    internal class AutoMapperTestUtils
    {
        public static IMapper BuildCoreMapper()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClassesMapperRegistrar>();
            }).CreateMapper();
        }
    }
}
