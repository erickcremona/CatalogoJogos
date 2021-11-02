using ExemploApiCatalogoJogos.Api.Configurations;
using ExemploApiCatalogoJogos.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploApiCatalogoJogos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            // Carregar banco de dados na memória
            services.AddDbContext<JogoContext>(option => option.UseInMemoryDatabase("JogoDb"));

            // Configure a ConnectionString no appsettings.json para utilizar banco de dados SQLServer
            //services.AddDbContext<JogoContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityConfig(Configuration);
            services.AddApiConfig();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerConfig();
            services.ResolverDependencias();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);
            app.UseSwaggerConfig(provider);
        }
    }
}
