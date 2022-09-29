using API.Data;
using API.Filters;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<LogUserActivity>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
