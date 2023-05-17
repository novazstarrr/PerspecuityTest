using Microsoft.Extensions.DependencyInjection;
using PerspicuityTest.Core.DataAccess.Classes.Readers;
using PerspicuityTest.Core.DataAccess.Classes.Readers.Implementations;
using PerspicuityTest.Core.DataAccess.Classes.Writers;
using PerspicuityTest.Core.DataAccess.Classes.Writers.Implementations;

namespace PerspicuityTest.Core.Utilities
{
    public static class CoreInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(CoreInstaller).Assembly);
            });

            services.AddAutoMapper(typeof(CoreInstaller).Assembly);

            services.AddTransient<IGetAllClassesReader, GetAllClassesReader>();
            services.AddTransient<IGetClassByIdReader, GetClassByIdReader>();
            services.AddTransient<ICreateClassWriter, CreateClassWriter>();
            services.AddTransient<IUpdateClassWriter, UpdateClassWriter>();
            services.AddTransient<IDeleteClassWriter, DeleteClassWriter>();
        }
    }
}
