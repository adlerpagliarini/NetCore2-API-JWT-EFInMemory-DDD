using ApiJwtEFInMemory.Domain.Interfaces.Repositories;
using ApiJwtEFInMemory.Domain.Interfaces.Services;
using ApiJwtEFInMemory.Domain.Services;
using ApiJwtEFInMemory.Infra.Context;
using ApiJwtEFInMemory.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiJwtEFInMemory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            //services.AddScoped<UsuarioService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
