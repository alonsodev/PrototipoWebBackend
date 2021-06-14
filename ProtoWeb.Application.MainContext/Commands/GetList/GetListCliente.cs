using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Net.Constantes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.GetList
{
    public class GetListCliente : IGetListCliente
    {
        readonly IClienteReadOnlyRepository ClienteReadOnlyRepository;

        public GetListCliente(
            IClienteReadOnlyRepository ClienteReadOnlyRepository)
        {
            this.ClienteReadOnlyRepository = ClienteReadOnlyRepository;
        }

        public async Task<Tuple<int, List<ClienteReadOnly>>> ObtenerPaginadoAsync(
            FiltroCliente filtro)
        {
            return await ClienteReadOnlyRepository.GetListFilter(
                filtro);
        }
    }
}
