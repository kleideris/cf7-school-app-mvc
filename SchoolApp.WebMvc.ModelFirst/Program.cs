using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SchoolApp.WebMvc.ModelFirst.Configuration;
using SchoolApp.WebMvc.ModelFirst.Data;
using SchoolApp.WebMvc.ModelFirst.Repositories;
using SchoolApp.WebMvc.ModelFirst.Services;
using Serilog;

namespace SchoolApp.WebMvc.ModeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SchoolAppDbContext>(options => options.UseSqlServer(connString));

            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            builder.Services.AddAutoMapper(cfg => { cfg.AddMaps(typeof(MapperConfig).Assembly); });
            builder.Services.AddRepositories();
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(option =>
               {
                   option.LoginPath = "/User/Login";
                   option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
               });



            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
