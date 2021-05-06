using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSP.BetterCalm.BusinessLogic;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.DataAccess.Interface;

namespace MSP.BetterCalm.WebApi
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

            services.AddControllers();

            services.AddDbContext<DbContext, DataContext>(
               o => o.UseInMemoryDatabase("BetterCalmDBIM")
           );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAdministratorLogic, AdministratorLogic>();
            services.AddScoped<IAudioLogic, AudioLogic>();
            services.AddScoped<IPlaylistLogic, PlaylistLogic>();
            services.AddScoped<IPathologyLogic, PathologyLogic>();
            services.AddScoped<ICategoryLogic, CategoryLogic>();
            services.AddScoped<IConsultationLogic, ConsultationLogic>();


            // services.AddScoped<IAudioLogic, AudioLogic>();
            // services.AddScoped<IPlaylistLogic, PlaylistLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
