﻿using AuthService.Infrastructure.Commands.Commands;
using AuthService.Infrastructure.Commands.Interfaces;
using AuthService.Infrastructure.Helpers;
using AuthService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Commands.Handlers
{
    public class LoginUserHandler : ICommandHandler<ExtendedLoginUserCommand>
    {
        private readonly IAuthService authService;

        public LoginUserHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<ContentResult> HandleAsync(ExtendedLoginUserCommand command)
        {  
            return (await authService.LoginAsync(command.Email, command.Username, command.Password, command.RemoteIpAddress))
                                     .SerializeToResult();
        }
    }
}
