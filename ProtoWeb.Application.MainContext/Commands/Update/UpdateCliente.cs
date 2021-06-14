﻿using ProtoWeb.Application.Core.Exceptions;
using ProtoWeb.Application.MainContext.Commands.Register;
using ProtoWeb.Domain.Core;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using ProtoWeb.Infra.Data.Agent.FileUploadAgent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Update
{
    public class UpdateCliente : IUpdateCliente
    {
        readonly IClienteReadOnlyRepository ClienteReadOnlyRepository;
        readonly IClienteWriteOnlyRepository ClienteWriteOnlyRepository;
        readonly IUnitOfWork unitOfWork;

        public UpdateCliente(
             IClienteReadOnlyRepository ClienteReadOnlyRepository,
            IClienteWriteOnlyRepository ClienteWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            this.ClienteReadOnlyRepository = ClienteReadOnlyRepository;
            this.ClienteWriteOnlyRepository = ClienteWriteOnlyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> ActualizarAsync(
            Cliente Cliente)
        {
            var searchResult = await ClienteReadOnlyRepository.GetByCorreo(Cliente.Correo, Cliente.Id);
            if (searchResult != null)
                throw new ClienteExistenteException();

            var id = Cliente.Id;
            var ClienteBd = ClienteReadOnlyRepository.Get(id);

            


            ClienteBd.Modificar(Cliente);
            using (var scope = unitOfWork.BeginTransaction())
            {
                ClienteWriteOnlyRepository.Modify(ClienteBd);
                await unitOfWork.CommitAsync();
                scope.Commit();
            }
            return id;
        }
    }
}
