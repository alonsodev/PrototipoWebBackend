using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Get
{
    public interface IGetCliente
    {
        Task<ClienteReadOnly> ObtenerAsync(int id);
    }
}