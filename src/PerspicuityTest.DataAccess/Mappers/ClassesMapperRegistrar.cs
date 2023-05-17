using AutoMapper;

namespace PerspicuityTest.Core.Mappers
{
    internal class ClassesMapperRegistrar : Profile
    {
        public ClassesMapperRegistrar()
        {
            CreateMap<Dtos.Class, Database.Models.Class>();
            CreateMap<Database.Models.Class, Dtos.Class>();
        }
    }
}
