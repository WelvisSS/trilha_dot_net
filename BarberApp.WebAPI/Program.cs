using BarberApp.Application.Services;
using BarberApp.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using BarberApp.Infrastructure.Persistence.Context;
using BarberApp.Infrastructure.Auth;
using BarberApp.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddDbContext<BarberAppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("BarberAppDb");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
