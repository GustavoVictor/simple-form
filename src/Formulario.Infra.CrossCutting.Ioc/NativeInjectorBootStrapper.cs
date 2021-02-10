using Microsoft.Extensions.DependencyInjection;
using Formulario.Domain.Interfaces.Identities;
using Formulario.Domain.Entities;
using Formulario.Domain.Repositories;
using Formulario.Infra.CrossCutting.Auth.Facades;
using Formulario.Infra.Data;

namespace Formulario.Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<Context>();

            //Auth
            services.AddScoped<ITokenFacade, TokenFacade>();

            //Domain
            services.AddScoped<IUser, User>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
