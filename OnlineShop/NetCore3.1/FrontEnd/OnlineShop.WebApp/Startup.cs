using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.WebApp.Helpers;
using OnlineShop.WebApp.Services.IServices;
using OnlineShopWebApp;
using Serilog;
using System;

namespace OnlineShop.WebApp
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
            services.AddHttpClient<IProductService, IProductService>();
            StaticDetails.ProductAPIBase = Configuration["ServiceUrls:ProductAPI"];
            services.AddScoped<IProductService, IProductService>();
            services.AddControllersWithViews();

            string connection = Configuration.GetConnectionString("online_shop");

            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(connection));

            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<IdentityContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<ICartsStorage, CartsDbStorage>();
            services.AddTransient<IProductsStorage, ProductsDbStorage>();
            services.AddTransient<IFavoriteStorage, FavoriteDbStorage>();
            services.AddTransient<ICompareStorage, CompareDbStorage>();
            services.AddTransient<IOrdersStorage, OrdersDbStorage>();
            services.AddSingleton<IRolesStorage, InMemoryRolesStorage>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "AdminArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}