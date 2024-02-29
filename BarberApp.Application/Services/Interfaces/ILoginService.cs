using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
using BarberApp.Infrastructure.Auth;
using BarberApp.Infrastructure.Persistence.Context;

namespace BarberApp.Application.Services.Interfaces;

public interface ILoginService
{
    public LoginViewModel LoginClient(NewLoginInputModel login);
    public LoginViewModel LoginEmployee(NewLoginInputModel login);

}
