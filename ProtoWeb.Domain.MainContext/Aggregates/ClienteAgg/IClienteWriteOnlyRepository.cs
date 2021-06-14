using ProtoWeb.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg
{
    public interface IClienteWriteOnlyRepository : IWriteOnlyRepository<Cliente>
    {
    }
}
