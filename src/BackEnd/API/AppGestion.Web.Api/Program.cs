using AppGestion.Application.Extensions;
using AppGestion.Application.ServiceConfiguration;
using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Identity.Identity.Dtos;
using AppGestion.Infrastructure.Identity.ServiceConfiguration;
using AppGestion.Infrastructure.Persistence.ServiceConfiguration;
using AppGestion.WebFramework.Middlewares;
using AppGestion.WebFramework.ServiceConfiguration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));
var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

builder.Services.AddControllers(options =>
{
    
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = true;
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices()
    .RegisterIdentityServices(identitySettings!)
    .AddPersistenceServices(configuration)
    .AddWebFrameworkServices();

builder.Services.RegisterValidatorsAsServices();
builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddAutoMapper(expression =>
{
    expression.AddMaps(typeof(User)/*, typeof(JwtService), typeof(UserController)*/);
});

var app = builder.Build();

await app.ApplyMigrationsAsync();
await app.SeedDefaultUsersAsync();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseExceptionHandler(_=>{});
app.UseSwaggerUI();
app.UseRouting();

app.UseHttpsRedirection();
// app.UseCors();
app.MapControllers();


await app.RunAsync();
