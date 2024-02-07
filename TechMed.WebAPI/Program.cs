using Microsoft.EntityFrameworkCore;
using TechMed.Application.Services;
using TechMed.Application.Services.Interfaces;
using TechMed.Infrastructure.Persistence;
using TechMed.Infrastructure.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<TechMedDbContext, TechMedDbContext>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IExameService, ExameService>();

builder.Services.AddDbContext<TechMedDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("TechMedDb");

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
