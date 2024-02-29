using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Verificar se a solicitação é para os endpoints da entidade "Perfil"
        if (context.Request.Path.StartsWithSegments("/api/v0.1/perfil"))
        {
            // Verificar se o usuário autenticado tem permissão de "Admin" em seu perfil
            if (!context.User.IsInRole("Admin"))
            {
                // Se o usuário não tem permissão de "Admin", negar acesso
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Acesso negado. Permissão de Admin necessária.");
                return;
            }
        }

        // Verificar se a solicitação é para os endpoints da entidade "Sistema"
        if (context.Request.Path.StartsWithSegments("/api/v0.1/sistema"))
        {
            // Verificar se o usuário autenticado tem permissão de "Admin" em seu perfil
            if (!context.User.IsInRole("Admin"))
            {
                // Se o usuário não tem permissão de "Admin", negar acesso
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Acesso negado. Permissão de Admin necessária.");
                return;
            }
        }

        // Verificar se a solicitação é para os endpoints da entidade "Evento"
        if (context.Request.Path.StartsWithSegments("/api/v0.1/eventos"))
        {
            // Verificar se o usuário autenticado tem permissão de "Admin" em seu perfil
            if (!context.User.IsInRole("Admin"))
            {
                // Se o usuário não tem permissão de "Admin", negar acesso
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Acesso negado. Permissão de Admin necessária.");
                return;
            }
        }

        // Se a solicitação não corresponde aos endpoints das entidades
        // "Perfil", "Sistema" ou "Evento", ou o usuário tem permissão de "Admin",
        // continuar para o próximo middleware
        await _next(context);
    }
}
