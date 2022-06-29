namespace FeedbackService.Api
{
    public static class ServiceExtensions
    {

        //cors : allow browser to allow any requests
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(
                 options =>
                 {
                     options.AddPolicy("CorsPolicy",
                     builder => builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader());
                 });
        }
    }
}