using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolApp.WebMvcDbFirst.Configuration;
using SchoolApp.WebMvcDbFirst.Data;
using SchoolApp.WebMvcDbFirst.Repositories;
using SchoolApp.WebMvcDbFirst.Services;
using Serilog;

namespace SchoolApp.WebMvcDbFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");

            // AddDbContext is scoped - per request a new instance of dbcontext is created
            builder.Services.AddDbContext<MvcDbContext>(options => options.UseSqlServer(connString));
            builder.Services.AddRepositories();
            builder.Services.AddRepositories();
            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/User/Login";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(MapperConfig).Assembly); }); // cfg => { cfg.AddMaps(typeof(MapperConfig).Assembly); }
            builder.Services.AddScoped<IApplicationService, ApplicationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
