using DataAccessEF.Interfaces;
using DataAccessEF.UnitOfWork;
using Domain;
using Domain.Entities.TableClass;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;

namespace WebAPI
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
            var sql = Configuration["SqlConnectionString"];
            services.AddDbContext<TrainingContext>(options =>
            options.UseSqlServer(Configuration["SqlConnectionString"])
            );
            services.AddServices();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IGenericRepository<MD_Customer>), typeof(GenericRepository<MD_Customer>));
            services.AddTransient(typeof(IGenericRepository<SAM_UserAccount>), typeof(GenericRepository<SAM_UserAccount>));
            services.AddTransient(typeof(IGenericRepository<SAM_UserInRole>), typeof(GenericRepository<SAM_UserInRole>));
            services.AddTransient(typeof(IGenericRepository<SAM_Role>), typeof(GenericRepository<SAM_Role>));
            services.AddTransient(typeof(IGenericRepository<SAM_FuncInRole>), typeof(GenericRepository<SAM_FuncInRole>));
            services.AddTransient(typeof(IGenericRepository<SAM_Function>), typeof(GenericRepository<SAM_Function>));
            services.AddTransient(typeof(IGenericRepository<SAM_Module>), typeof(GenericRepository<SAM_Module>));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
