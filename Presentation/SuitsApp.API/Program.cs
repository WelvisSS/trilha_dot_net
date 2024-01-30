using Microsoft.EntityFrameworkCore;
using SuitsApp.Application.Services;
using SuitsApp.Application.Services.Interfaces;
using SuitsApp.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<SuitsAppDbContext, TechMedContext>();
builder.Services.AddScoped<IClientService, ClientService>();
// builder.Services.AddScoped<IPacienteService, PacienteService>();
// builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
// builder.Services.AddScoped<IExameService, ExameService>();

builder.Services.AddDbContext<SuisAppDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("SuitsAppDb");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

      options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
