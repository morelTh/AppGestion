using AppGestion.Application.ServiceConfiguration;
using AppGestion.Infrastructure.Identity.Identity.Dtos;
using AppGestion.Infrastructure.Identity.ServiceConfiguration;
using AppGestion.Infrastructure.Persistence.ServiceConfiguration;
using AppGestion.WebFramework.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.Configure<IdentitySettings>(configuration.GetSection(nameof(IdentitySettings)));
var identitySettings = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices()
    .RegisterIdentityServices(identitySettings!)
    .AddPersistenceServices(configuration)
    .AddWebFrameworkServices();

var app = builder.Build();

await app.ApplyMigrationsAsync();
await app.SeedDefaultUsersAsync();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
}
app.UseSwaggerUI();
app.UseHttpsRedirection();
// app.UseCors();
app.MapControllers();


await app.RunAsync();
