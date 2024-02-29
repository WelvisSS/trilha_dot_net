
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ResTIConnect.Aplication;
using ResTIConnect.Aplication.Services;
using ResTIConnect.Aplication.Services.Interfaces;
using ResTIConnect.Infrastructure.Auth;
using ResTIConnect.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddSingleton<IResTIConnectContext, ResTIConnectContext>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddDbContext<ResTIConnectDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ResTIConnectDb");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

    options.UseMySql(connectionString, serverVersion);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy =>
        policy.RequireRole("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AuthorizationMiddleware>();

app.MapControllers();

app.Run();

// // Adiciona a função de administrador
// var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
// if (!await roleManager.RoleExistsAsync("Admin"))
// {
//     await roleManager.CreateAsync(new IdentityRole("Admin"));
// }
//
// // Cria um usuário e atribui a função de administrador a ele
// var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
// var user = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
// var result = await userManager.CreateAsync(user, "SuaSenhaAqui");
// if (result.Succeeded)
// {
//     await userManager.AddToRoleAsync(user, "Admin");
// }
