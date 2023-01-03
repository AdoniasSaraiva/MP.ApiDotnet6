using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.ApiDotnet6.Application.Mappings;
using MP.ApiDotnet6.Application.Services;
using MP.ApiDotnet6.Application.Services.Interface;
using MP.ApiDotnet6.Infra.Data.Authentication;
using MP.ApiDotnet6.Infra.Data.Context;
using MP.ApiDotnet6.Infra.Data.Integrations;
using MP.ApiDotnet6.Infra.Data.Repositories;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.Integrations;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContextDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>(); 
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonImageRepository, PersonImageRepository>();
            services.AddScoped<ISavePersonImage, SavePersonImage>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(DomainToDtoMapping));
            service.AddScoped<IPersonService, PersonService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IPurchaseService, PurchaseService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IPersonImageService, PersonImageService>();

            return service;
        }
    }
}