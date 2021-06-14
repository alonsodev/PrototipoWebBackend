using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Register
{
    public interface IRegisterCliente
    {
        Task<int> RegistrarAsync(Cliente Cliente);
    }
}