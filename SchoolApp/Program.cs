using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SchoolApp.Data;
using SchoolApp.Repositories;
using SchoolApp.Services;
using Serilog;
using System.Text;
using UsersStudentsMVCApp.Configuration;

namespace SchoolApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SchoolAppDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddRepositories();

            builder.Services.AddScoped(provider =>
              new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile(new MapperConfig());
              })
          .CreateMapper());

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtSettings = builder.Configuration.GetSection("Authentication");
                options.IncludeErrorDetails = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidIssuer = "https://codingfactory.aueb.gr",

                    ValidateAudience = false,
                    ValidAudience = "https://api.codingfactory.aueb.gr",

                    ValidateLifetime = true, // ensure not expired

                    ValidateIssuerSigningKey = true,

                    // US2BlUEkNFMy8yl0t6subj3cJKhAm7kQ7Asg7-mSwq0
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    //.GetBytes("US2BlUEkNFMy8yl0t6subj3cJKhAm7kQ7Asg7-mSwq0"))
                    .GetBytes(jwtSettings["SecretKey"]!))
                    //.GetBytes(builder.Configuration["Authentication: SecretKey"]!))

                };
            });

            // Add services to the container.

            builder.Services.AddCors(options => {
                options.AddPolicy("AllowAll",
                    b => b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });

            builder.Services.AddCors(options => {
                options.AddPolicy("AngularClient",
                    b => b.WithOrigins("http://localhost:4200") // Assuming Angular runs on localhost:4200
                          .AllowAnyMethod()
                          .AllowAnyHeader());
            });

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
