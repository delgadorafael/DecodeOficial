using Autofac;
using DecodeOficial.Application.Interfaces;
using DecodeOficial.Application.Servicies;
using DecodeOficial.Domain.Interfaces.Repositories;
using DecodeOficial.Domain.Interfaces.Servicies;
using DecodeOficial.Domain.Servicies;
using DecodeOficial.Infrastructure.Data.Repositories;

namespace DecodeOficial.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServicePerson>().As<IApplicationServicePerson>();
            builder.RegisterType<ServicePerson>().As<IServicePerson>();
            builder.RegisterType<RepositoryPerson>().As<IRepositoryPerson>();
        }
    }
}
