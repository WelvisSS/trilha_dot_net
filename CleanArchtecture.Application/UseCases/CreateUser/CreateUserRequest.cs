using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchtecture.Application.UseCases.CreateUser
{
        public sealed record CreateUserRequest(string Email, string Name) : IRequest<CreateUserResponse>;
}

