using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodAndGo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAndGo.Repositories;
using FoodAndGo.Services;
using FluentValidation.AspNetCore;
using FoodAndGo.Data.ViewModels.Validator;

namespace FoodAndGo
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<FoodinputValidator>()); 
            
            services.AddMvc();
          

            services.AddDbContext<FoodAndGoContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFoodService, FoodService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");
            });
        }
    }

}
