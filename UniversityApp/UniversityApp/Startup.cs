using System.Reflection.Metadata;
using UniversityApp.Abstractions;
using UniversityApp.Data;
using UniversityApp.Services;

namespace UniversityApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseCors(option => option.AllowAnyMethod()
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader());
            app.UseEndpoints(endpoint =>
            {  
                endpoint.MapControllers();
            });
            app.UseAuthorization();

            app.Run();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddEndpointsApiExplorer();

            services.AddDbContext<UniDbContext>();

            services.AddCors();
            services.AddScoped<IDepartmentServices, DepartmentServices>();
        }
    } 
}
