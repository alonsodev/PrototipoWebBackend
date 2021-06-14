using System.Threading.Tasks;

namespace ProtoWeb.Application.MainContext.Commands.Delete
{
    public interface IDeleteCliente
    {
        Task DeleteAsync(int id);
    }
}