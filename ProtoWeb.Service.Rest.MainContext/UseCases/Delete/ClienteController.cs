using ProtoWeb.Application.MainContext.Commands.Delete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.UseCases.Delete
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IDeleteCliente deleteCliente;

        public ClienteController(
            IDeleteCliente deleteCliente)
        {
            this.deleteCliente = deleteCliente;
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            await deleteCliente.DeleteAsync(id);
            return Ok(true);
        }
    }
}
