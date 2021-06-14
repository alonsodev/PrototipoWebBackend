using ProtoWeb.Application.MainContext.Commands.Get;
using ProtoWeb.Infra.CrossCutting.Adapter;
using ProtoWeb.Service.Rest.Dto.Cliente;
using ProtoWeb.Service.Rest.MainContext.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.UseCases.Get
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IGetCliente getCliente;

        public ClienteController(
            IGetCliente getCliente)
        {
            this.getCliente = getCliente;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> ObtenerAsync(int id)
        {
            var ClienteMantenimiento = await getCliente.ObtenerAsync(id);
            return Ok(ClienteMantenimiento.ProjectedAs<ClienteDto>());
        }
    }
}
