using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProtoWeb.Domain.Core;
namespace ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg
{
    public interface IClienteReadOnlyRepository : IReadOnlyRepository<Cliente>
    {
        Task<Cliente> GetById(int id);
        Task<ClienteReadOnly> GetByIdReadOnly(int id);

        Task<Tuple<int, List<ClienteReadOnly>>> GetListFilter(FiltroCliente filtro);
        Task<ClienteReadOnly> GetByCorreo(string correo, int id);
    }
}
