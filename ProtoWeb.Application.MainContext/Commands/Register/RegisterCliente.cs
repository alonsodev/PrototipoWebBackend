using ProtoWeb.Application.Core.Exceptions;
using ProtoWeb.Domain.Core;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using ProtoWeb.Infra.Data.Agent.FileUploadAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Register
{
    public class RegisterCliente : IRegisterCliente
    {
        readonly IClienteReadOnlyRepository ClienteReadOnlyRepository;
        readonly IClienteWriteOnlyRepository ClienteWriteOnlyRepository;
        readonly IUnitOfWork unitOfWork;

        public RegisterCliente(
            IClienteReadOnlyRepository ClienteReadOnlyRepository,
            IClienteWriteOnlyRepository ClienteWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            this.ClienteReadOnlyRepository = ClienteReadOnlyRepository;
            this.ClienteWriteOnlyRepository = ClienteWriteOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> RegistrarAsync(
            Cliente Cliente
        )
        {
            var searchResult = await ClienteReadOnlyRepository.GetByCorreo(Cliente.Correo, Cliente.Id);
            if (searchResult != null)
                throw new ClienteExistenteException();

            Cliente.Crear(Cliente);
            using (var scope = unitOfWork.BeginTransaction())
            {
                ClienteWriteOnlyRepository.Add(Cliente);
                await unitOfWork.CommitAsync();

                scope.Commit();
            }

            return Cliente.Id;
        }

    }
}
