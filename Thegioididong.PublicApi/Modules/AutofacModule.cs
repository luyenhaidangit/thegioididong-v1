using Autofac;
using System.Reflection;
using Thegioididong.Data;
using Thegioididong.Data.Repositories;
using Thegioididong.Service;


namespace Thegioididong.PublicApi.Modules
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Đăng ký dependencies ở đây
            var dataAssembly = Assembly.GetAssembly(typeof(ProductRepository));
            builder.RegisterAssemblyTypes(dataAssembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            var serviceAssembly = Assembly.GetAssembly(typeof(ProductService));
            builder.RegisterAssemblyTypes(serviceAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
