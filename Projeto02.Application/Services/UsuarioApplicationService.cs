using MediatR;
using Projeto02.Application.Commands.Usuarios;
using Projeto02.Application.Interfaces;
using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IMediator mediator;

        public UsuarioApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Create(UsuarioCreateCommand command)
        {
            mediator.Send(command);
        }
    }
}
