using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Formulario.Infra.CrossCutting.Auth.Providers;
using Formulario.Infra.CrossCutting.Ioc;

namespace Formulario.Services.Host
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ProjectStream Back-end",
                        Version = "v1",
                        Description = "API REST desenvolvida com ASP .NET Core 2.2 para a aplicação <b>[ProjectStream] </b>",
                        Contact = new OpenApiContact
                        {
                            Name = "GVS Serviços de Informatica",
                        }
                    });

                var _security = new OpenApiSecurityRequirement();

                _security.Add(new OpenApiSecurityScheme{ BearerFormat = "Bearer {}"}, new string[] { });
                
                options.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Utilização: Escreva 'Bearer {seuToken}'",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { 
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer" 
                        } 
                    },
                    new string[] { } 
                    } 
                });
            });

            services.RegisterServices();
            services.AddJWT(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwagger()
                   .UseSwaggerUI(c =>
                   {
                       /* Rota para acessar a documentação */
                       c.RoutePrefix = "documentation";
                   
                       /* Não alterar: Configuração aplicável tanto para servidor quanto para localhost */
                       c.SwaggerEndpoint("../swagger/v1/swagger.json", "Documentação API v1");
                   });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
