using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.GetList
{
    public interface IGetListCliente
    {
        Task<Tuple<int, List<ClienteReadOnly>>> ObtenerPaginadoAsync(
            FiltroCliente filtro);
    }
}