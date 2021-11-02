using ExemploApiCatalogoJogos.Application.Interfaces;
using ExemploApiCatalogoJogos.Application.Services;
using ExemploApiCatalogoJogos.Data.Context;
using ExemploApiCatalogoJogos.Data.Repository;
using ExemploApiCatalogoJogos.Domain.Interfaces;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;
using ExemploApiCatalogoJogos.Domain.Interfaces.Service;
using ExemploApiCatalogoJogos.Domain.Notifications;
using ExemploApiCatalogoJogos.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Api.Configurations
{
    public static class DIConfig
    {
        public static void ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<JogoContext>();
            services.AddScoped<IRepositoryJogo, RepositoryJogo>();
            services.AddScoped<IServiceJogo, DomainServiceJogo>();
            services.AddScoped<IAppServiceJogo, AppServiceJogo>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
