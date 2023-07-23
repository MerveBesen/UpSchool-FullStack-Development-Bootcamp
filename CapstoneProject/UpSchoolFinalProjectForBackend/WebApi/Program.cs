
using Application.Common.Interfaces;
using Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Hubs;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

//Localizations Files Path

    builder.Services.AddSignalR();

    builder.Services.AddScoped<ILogHubService, LogHubManager>();
    
    builder.Services.AddScoped<IOrderHubService, OrderHubManager>();

builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

  //  builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseStaticFiles();

// Localization
    var requestLocalizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
    if (requestLocalizationOptions is not null) app.UseRequestLocalization(requestLocalizationOptions.Value);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

app.UseCors("AllowAll");

    app.MapHub<LogHub>("/Hubs/LogHub");

    app.Run();
    

