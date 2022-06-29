using AutoMapper;
using FeedbackService.Api;
using FeedbackService.Core.Services;
using FeedbackService.Infrastructure;
using FeedbackService.Infrastructure.Interfaces.Repositories;
using FeedbackService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




// Configure Cors   
builder.Services.ConfigureCors();


// Configure Dependency Injection
builder.Services.ConfigureDependencyInjection(builder.Configuration);




builder.Services.AddControllers();

//Configure Swagger by me :

builder.Services.ConfigureSwagger();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

string currentEnvironement = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, reloadOnChange: true);

if(currentEnvironement?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
{
    configurationBuilder.AddJsonFile($"appsettings.{currentEnvironement}.json", optional: true);
}

try
{
    
}catch(Exception ex)
{
    throw;
}






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
//    app.UseSwagger();
  //  app.UseSwaggerUI();
  app.UseDeveloperExceptionPage();  //exception in page
}


//Configure Swagger also by me
app.ConfigureSwagger();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); 
