
using ASP_Event_Project.Filtr;
using ASP_Event_Project.Mock;
using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("AppIdentity")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<ICrudCategoryRepository, CrudCategoryRepository>();
            services.AddTransient<ICrudEventRepository, CrudEventRepository>();
            services.AddTransient<ICustomerEventRepository, CustomerEventRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddControllersWithViews();
            services.AddMvc()
            .AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "my_events", Version = "v1" });
            });
            services.AddDistributedMemoryCache();
            /*services.AddSingleton<BasicAuthorizationFilter>();
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.AddService<BasicAuthorizationFilter>();
            });*/
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "my_events v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EventManagment}/{action=Index}/{id?}");
            });
            
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
