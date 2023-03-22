using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieRental.Data.Context;
using MovieRental.Data.InitialData;
using MovieRental.Data.Repositories;
using MovieRtaFilms.Data.InitialData;
using System;

namespace MovieRental.Presentation
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
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddHttpContextAccessor();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(
                options =>
                {
                    options.UseSqlServer(
                        Configuration.GetConnectionString("Default")
                    );
                }
                );
            services.AddTransient<IInitialData, InitialData>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IRentService, RentService>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Rent}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<IInitialData>().StartDb();

        }
    }
}
