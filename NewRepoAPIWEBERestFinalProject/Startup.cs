using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewRepoAPIWEBERestFinalProject.Models;
using NewRepoAPIWEBERestFinalProject.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using NewRepoAPIWEBERestFinalProject.Middlewares;
using NewRepoAPIWEBERestFinalProject.Services.Interfaces;
using NewRepoAPIWEBERestFinalProject.Services.Implementations;
using NewRepoAPIWEBERestFinalProject.Configuration;

namespace NewRepoAPIWEBERestFinalProject
{
    public class Startup
    {
        private IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IPatientsRepository, SqlPatientsRepository>();
            services.AddScoped<IServicesRepository, SqlServicesRepository>();
            services.AddScoped<IOrdersRepository, SqlOrdersRepository>();
            services.AddScoped<IMessageService<Email>, EmailMessageService>();
            //services.AddScoped<IMessageService<Sms>, SmsMessageService>();
            //DbContext
            services.AddDbContext<NewRepoAPIWEBRestFinalProjectContext>(builder => builder.UseSqlServer(_configuration.GetConnectionString("NewRepoAPIWEBRestFinalProjectDbConnectionNew")).UseLazyLoadingProxies());

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<NewRepoAPIWEBRestFinalProjectContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddMemoryCache();
            // services.AddHostedService<LoadFileService>();
            //services.AddHostedService<UploadFileService>();

            var section = _configuration.GetSection("NewNewRepoAPIWEBRestFinalProject");
            services.Configure<NewRepoAPIWEBERestFinalProjectConfiguration>(section);

            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            }
            );

      

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseWriteToConsole("Middleware 1");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseWriteToConsole("Middleware 2");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
