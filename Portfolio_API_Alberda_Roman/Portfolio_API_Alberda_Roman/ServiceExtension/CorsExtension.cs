using Microsoft.Extensions.DependencyInjection;

namespace Portfolio_API_Alberda_Roman.ServiceExtension
{
    public static class CorsExtension
    {
        public static void AddCorsSettings(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    //.WithExposedHeaders("Token-Expired", "InvalidRefreshToken", "InvalidCredentials")
                    .WithOrigins("http://localhost:3000", "http://localhost:8080", "http://localhost:4200")
                    .Build());
            });
    }
}
