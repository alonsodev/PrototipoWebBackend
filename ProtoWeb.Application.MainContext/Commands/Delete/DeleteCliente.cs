using ProtoWeb.Domain.Core;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using ProtoWeb.Infra.Data.Agent.FileUploadAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Delete
{
    public class DeleteCliente : IDeleteCliente
    {
        readonly IClienteReadOnlyRepository ClienteReadOnlyRepository;
        readonly IClienteWriteOnlyRepository ClienteWriteOnlyRepository;

        readonly IUnitOfWork unitOfWork;

        public DeleteCliente(
            IClienteReadOnlyRepository ClienteReadOnlyRepository,
            IClienteWriteOnlyRepository ClienteWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            this.ClienteReadOnlyRepository = ClienteReadOnlyRepository;
            this.ClienteWriteOnlyRepository = ClienteWriteOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(int id)
        {
            var Cliente = ClienteReadOnlyRepository.Get(id);

            using (var scope = unitOfWork.BeginTransaction())
            {
                ClienteWriteOnlyRepository.Remove(Cliente);
                await unitOfWork.CommitAsync();
                scope.Commit();
            }
        }
    }
}
