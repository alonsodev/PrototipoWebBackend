using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Update
{
    public interface IUpdateCliente
    {
        Task<int> ActualizarAsync(Cliente Cliente);
    }
}