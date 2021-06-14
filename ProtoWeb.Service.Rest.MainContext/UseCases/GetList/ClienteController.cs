using ProtoWeb.Application.MainContext.Commands.GetList;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using ProtoWeb.Infra.CrossCutting.Adapter;
using ProtoWeb.Service.Rest.Dto.Cliente;
using ProtoWeb.Service.Rest.MainContext.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.UseCases.GetList
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IGetListCliente getListCliente;

        public ClienteController(
            IGetListCliente getListCliente)
        {
            this.getListCliente = getListCliente;
        }

        [HttpGet, Route("paginado")]
        public async Task<IActionResult> ListarPaginadoAsync([FromQuery] FiltroClienteDto filtros)
        {
            var resultado = await getListCliente.ObtenerPaginadoAsync(
                filtros.ProjectedAs<FiltroCliente>());


            return Ok(new
            {
                Total = resultado.Item1,
                Listado = resultado.Item2.ProjectedAs<List<GetListClienteResultDto>>()
            });
        }

    }
}
