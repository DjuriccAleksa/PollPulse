using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PollPulse.Entities.Models;
using PollPulse.Entities.Options;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces.Unit_of_work;
using PollPulse.Repository.Unit_of_work;

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
        }

        public static void ConfigureUnitOfWorkRepository(this IServiceCollection services) =>
            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        public static void AddSmtpConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            services.Configure<SmtpConfiguration>(configuration.GetSection("SmtpSettings"));
       
    }
}
