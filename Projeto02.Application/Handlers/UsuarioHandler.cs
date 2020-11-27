using MediatR;
using Projeto02.Application.Notifications;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto02.Application.Handlers
{
    public class UsuarioHandler : INotificationHandler<UsuarioNotification>
    {
        private readonly IUsuarioCache usuarioCache;

        public UsuarioHandler(IUsuarioCache usuarioCache)
        {
            this.usuarioCache = usuarioCache;
        }

        public Task Handle(UsuarioNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var usuarioDTO = new UsuarioDTO
                {
                    Id = notification.Usuario.Id,
                    Nome = notification.Usuario.Nome,
                    DataCriacao = notification.Usuario.DataCriacao
                };

                switch (notification.Action)
                {
                    case ActionNotification.Create:
                        usuarioCache.Create(usuarioDTO);
                        break;
                    case ActionNotification.Update:
                        usuarioCache.Update(usuarioDTO);
                        break;
                    case ActionNotification.Delete:
                        usuarioCache.Delete(usuarioDTO);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
