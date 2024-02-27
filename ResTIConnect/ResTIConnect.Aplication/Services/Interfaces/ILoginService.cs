using System.ComponentModel.DataAnnotations;
using ResTIConnect.Aplication.InputModels;
using ResTIConnect.Aplication.ViewModels;

namespace ResTIConnect.Aplication;

public interface ILoginService
{
    public string Login(NewLoginInputModel login);
}
