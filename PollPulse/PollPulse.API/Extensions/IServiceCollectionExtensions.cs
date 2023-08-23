using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PollPulse.API.OptionsSetup;
using PollPulse.Application.Interfaces.Services;
using PollPulse.Entities.Models;
using PollPulse.Entities.Options;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces.Unit_of_work;
using PollPulse.Repository.Unit_of_work;
using PollPulse.Services;
using PollPulse.Services.Email;

namespace PollPulse.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination");
            });
        });

        public static void ConfigureSqlSqerverContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<RepositoryContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureIdentity(this IServiceCollection services) {
            services.AddIdentity<User, IdentityRole<long>>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 8;

                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                opt.Lockout.AllowedForNewUsers = true;

                opt.User.RequireUniqueEmail = true;

                opt.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();

            services.AddDataProtection();

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));
        }

        public static void ConfigureUnitOfWorkRepository(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        public static void AddSmtpConfiguration(this IServiceCollection services) =>
            services.ConfigureOptions<SmtpConfigurationSetup>();

        public static void ConfigureAuthentication(this IServiceCollection services) =>
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer();

        public static void AddJwtConfiguration(this IServiceCollection services) =>
            services.ConfigureOptions<JwtConfigurationSetup>();

        public static void AddJwtBearerConfiguration(this IServiceCollection services) =>
            services.ConfigureOptions<JwtBearerConfigurationSetup>();

        public static void RegisterExternalServicesIntoDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtProviderService, JwtProviderService>();
        }
    }
}
