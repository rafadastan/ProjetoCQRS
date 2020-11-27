using MediatR;
using Projeto02.Application.Commands.Usuarios;
using Projeto02.Application.Notifications;
using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto02.Application.RequestHandlers
{
    public class UsuarioRequestHandler : IRequestHandler<UsuarioCreateCommand>
    {
        private readonly IMediator mediator;
        private readonly IUsuarioDomainService usuarioDomainService;

        public UsuarioRequestHandler(IMediator mediator, IUsuarioDomainService usuarioDomainService)
        {
            this.mediator = mediator;
            this.usuarioDomainService = usuarioDomainService;
        }

        public Task<Unit> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var usuarioEntity = new UsuarioEntity
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                DataCriacao = DateTime.Now
            };

            usuarioDomainService.Create(usuarioEntity);

            mediator.Publish(new UsuarioNotification
            {
                Usuario = usuarioEntity,
                Action = ActionNotification.Create
            });

            return Task.FromResult(new Unit());
        }
    }
}
