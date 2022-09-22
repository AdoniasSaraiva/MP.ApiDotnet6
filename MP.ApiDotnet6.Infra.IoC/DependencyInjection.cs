using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.ApiDotnet6.Application.Mappings;
using MP.ApiDotnet6.Application.Services;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotnet6.Infra.Data.Context;
using MP.ApiDotnet6.Infra.Data.Repositories;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            //service.AddDbContext<ApplicationContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("")));
            
            service.AddScoped<IPersonRepository, PersonRepository>();

            return service;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(DomainToDtoMapping));
            service.AddScoped<IPersonService, PersonService>();

            return service;
        }
    }
}