using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using ChillTechnologies.API.Commons;
using ChillTechnologies.Application;
using ChillTechnologies.Application.Interfaces;
using ChillTechnologies.Infrastructure.Configuration;

namespace ChillTechnologies.API.Configuration;

public static class ServiceRegistrationExtensions
{
    public const string CorsPolicy = "FrontendErp";

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddInfrastructureServices(configuration);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(ApplicationAssemblyMarker).Assembly
        ));
        
        var seccionCors = configuration.GetSection("Cors:Origenes");
        var origenes = seccionCors.Get<string[]>()
                       ?? seccionCors.Value?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                       ?? ["http://localhost:5173"];

        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, policy =>
                policy.WithOrigins(origenes)
                      .AllowAnyHeader()
                      .AllowAnyMethod());
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        services.AddAuthorization();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ChillTechnologies ERP API",
                Version = "v1",
                Description = "ERP de ChillTechnologies Peru S.A.C. - Clean Architecture con CQRS y MediatR."
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Pega el token que devuelve /api/Auth/login (sin escribir Bearer)"
            });
            options.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
            {
                { new OpenApiSecuritySchemeReference("Bearer", doc), new List<string>() }
            });
        });

        return services;
    }
}
