using FeedbackService.Core.Services;
using FeedbackService.Infrastructure;
using FeedbackService.Infrastructure.Interfaces.Repositories;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FeedbackService.Api
{
    public static  class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if(services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if(configuration == null)
            {
                 throw new ArgumentNullException(nameof(configuration));
            }
            services.AddDbContext<FeedbackDbContext>(opt => opt.UseInMemoryDatabase("InMem"));

            services.AddScoped<IFeedbackService, FeedbacksService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            return services;
        }

    }
}
