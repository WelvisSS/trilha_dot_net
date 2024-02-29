﻿namespace BarberApp.Infrastructure.Auth;

public interface IAuthService
{
    // string GenerateJwtToken(string email, string role);
    string ComputeSha256Hash(string pass);

    public string GenerateJwtToken(string email, string role);
}
