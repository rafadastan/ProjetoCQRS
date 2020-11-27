using Projeto02.Application.Commands.Usuarios;
using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        void Create(UsuarioCreateCommand command);
    }
}
