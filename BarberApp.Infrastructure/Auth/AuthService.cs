﻿using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BarberApp.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string ComputeSha256Hash(string pass)
    {
         using (var sha256 = SHA256.Create())
         {
               var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));
               var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
               return hash;
         }
    }
}
