using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Services
{
    public class TarefaDomainService : BaseDomainService<TarefaEntity>, ITarefaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TarefaDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.TarefaRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
