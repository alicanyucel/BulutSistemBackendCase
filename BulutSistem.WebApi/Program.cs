using BulutSistem.Appllication;
using BulutSistem.Infrastructure;
using BulutSistem.Infrastructure.Services;
using BulutSistem.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using StackExchange.Redis;
using System.Net;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        builder.Services.AddAuthentication().AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value ?? ""))
            };
        });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("EditorOnly", policy => policy.RequireRole("Editor"));
            options.AddPolicy("ViewerOnly", policy => policy.RequireRole("Viewer"));
        });

        builder.Services.AddSingleton<RedisCacheService>(); // di
        builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379,abortConnect=false")); //r edis start



        builder.Services.AddAuthorizationBuilder();
        Log.Logger = new LoggerConfiguration()
       .WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("SqlServer"),
        tableName: "Logs", 
        autoCreateSqlTable: true
       )
      .Enrich.FromLogContext()
      .CreateLogger();
        builder.Host.UseSerilog();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(setup =>
        {
            // jwt
            var jwtSecuritySheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors();
        app.UseAuthentication();  // JWT doðrulama
        app.UseAuthorization();
        app.MapControllers();
        ExtensionsMiddleware.CreateFirstUser(app);

        app.Run();
    }
}