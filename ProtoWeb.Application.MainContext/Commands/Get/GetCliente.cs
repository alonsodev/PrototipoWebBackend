using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Get
{
    public class GetCliente : IGetCliente
    {
        readonly IClienteReadOnlyRepository ClienteReadOnlyRepository;

        public GetCliente(
            IClienteReadOnlyRepository ClienteReadOnlyRepository)
        {
            this.ClienteReadOnlyRepository = ClienteReadOnlyRepository;
        }

        public async Task<ClienteReadOnly> ObtenerAsync(int id)
        {
            return await ClienteReadOnlyRepository.GetByIdReadOnly(id);
        }
    }
}
