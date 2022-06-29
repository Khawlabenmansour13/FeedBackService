namespace FeedbackService.Api
{
    public static class SwaggerConfiguration
    {

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }


            string serviceDescription = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "ServiceDescription.md"));

            services.AddSwaggerGen(c =>
            {
 
                
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "DocumentService.Api", Version = "v1" , Description = serviceDescription});
         
            });
        
            return services;
        }



        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            if(app == null)
            {
                throw new ArgumentNullException(nameof(app));   
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentService.Api v1"));

            return app;
        }
    }
}
