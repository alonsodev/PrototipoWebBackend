using ProtoWeb.Application.MainContext.Commands.Register;
using ProtoWeb.Application.MainContext.Commands.Update;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Adapter;
using ProtoWeb.Service.Rest.Dto.Cliente;
using ProtoWeb.Service.Rest.MainContext.Model;
using ProtoWeb.Service.Rest.MainContext.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.UseCases.Update
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IUpdateCliente updatCliente;

        public ClienteController(
            IUpdateCliente updatCliente)
        {
            this.updatCliente = updatCliente;
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarAsync([FromBody] RegisterClienteDto registerDto)
        {
            var Cliente = registerDto
                .ProjectedAs<Cliente>();
            var id = await updatCliente.ActualizarAsync(
                Cliente);
            return Ok(id);
        }
    }
}
