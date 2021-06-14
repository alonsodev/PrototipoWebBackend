using Microsoft.EntityFrameworkCore;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.Data.Core;
using ProtoWeb.Infra.Data.MainContext.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Infra.Data.MainContext.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteReadOnlyRepository, IClienteWriteOnlyRepository
    {
        readonly AppDbContext _context;

        public ClienteRepository(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext as AppDbContext;
        }

        #region IClienteWriteOnlyRepository
        #endregion

        #region IClienteReadOnlyRepository

        public async Task<Cliente> GetCliente(int id)
        {
            return await _context.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Cliente> GetById(int id)
        {
            var query = await (from cliente in _context.Cliente
                               where cliente.Id == id
                               select new Cliente
                               {
                                   Id = cliente.Id,
                                   Activo = cliente.Activo,
                                   Apellidos = cliente.Apellidos,
                                   FechaNacimiento = cliente.FechaNacimiento,
                                   Correo = cliente.Correo,
                                   Direccion = cliente.Direccion,
                                   FechaRegistro = cliente.FechaRegistro,
                                   Nombres = cliente.Nombres,
                               }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<ClienteReadOnly> GetByIdReadOnly(int id)
        {
            var query = await (from cliente in _context.Cliente
                               where cliente.Id == id
                               select new ClienteReadOnly
                               {
                                   Id = cliente.Id,
                                   Activo = cliente.Activo,
                                   Apellidos = cliente.Apellidos,
                                   FechaNacimiento = cliente.FechaNacimiento,
                                   Correo = cliente.Correo,
                                   Direccion = cliente.Direccion,
                                   FechaRegistro = cliente.FechaRegistro,
                                   Nombres = cliente.Nombres,
                               }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<ClienteReadOnly> GetByCorreo(string correo, int id)
        {
            var query = await (from cliente in _context.Cliente
                               where cliente.Correo == correo && cliente.Id != id && cliente.Activo
                               select new ClienteReadOnly
                               {
                                   Id = cliente.Id,
                                   Activo = cliente.Activo,
                                   Apellidos = cliente.Apellidos,
                                   FechaNacimiento = cliente.FechaNacimiento,
                                   Correo = cliente.Correo,
                                   Direccion = cliente.Direccion,
                                   FechaRegistro = cliente.FechaRegistro,
                                   Nombres = cliente.Nombres,
                               }).FirstOrDefaultAsync();
            return query;
        }

        public async Task<Tuple<int, List<ClienteReadOnly>>> GetListFilter(FiltroCliente filtro)
        {
            var query = (from cliente in _context.Cliente
                               where (String.IsNullOrEmpty(filtro.BuscarPor) || cliente.Nombres.Contains(filtro.BuscarPor) ||
                               cliente.Apellidos.Contains(filtro.BuscarPor) ||
                               cliente.Direccion.Contains(filtro.BuscarPor)) &&

                               (filtro.Estado == null || filtro.Estado == cliente.Activo)

                               orderby cliente.Nombres ascending, cliente.Apellidos ascending
                               select new ClienteReadOnly
                               {
                                   Id = cliente.Id,
                                   Activo = cliente.Activo,
                                   Apellidos = cliente.Apellidos,
                                   FechaNacimiento = cliente.FechaNacimiento,
                                   Correo = cliente.Correo,
                                   Direccion = cliente.Direccion,
                                   FechaRegistro = cliente.FechaRegistro,
                                   Nombres = cliente.Nombres,
                               });

            var total = await query.CountAsync();
            var lista = await query
                .Skip(filtro.Tamanio * (filtro.Pagina - 1))
                .Take(filtro.Tamanio)
                .ToListAsync();

            return Tuple.Create(total, lista);
        }

        

        #endregion
    }
}
