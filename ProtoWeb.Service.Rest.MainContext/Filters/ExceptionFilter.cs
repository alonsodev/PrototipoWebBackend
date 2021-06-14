using ProtoWeb.Application.Core.Exceptions;
using ProtoWeb.Domain.Core.Exceptions;
using ProtoWeb.Infra.CrossCutting.Net.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace ProtoWeb.Service.Rest.MainContext.Filters
{

    public sealed class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var formatJson = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() };
            string json;
            if (exception is ApplicationException)
            {
                ApplicationException ex = exception as ApplicationException;
                json = JsonConvert.SerializeObject(new { ex.IdOperacion, ex.Mensaje, ex.Accion }, formatJson);
            }
            else if (exception is DomainException)
            {
                DomainException ex = exception as DomainException;
                json = JsonConvert.SerializeObject(new { ex.IdOperacion, ex.Mensaje, ex.Accion }, formatJson);
            }
            else if (exception is InfrastructureException)
            {
                InfrastructureException ex = exception as InfrastructureException;
                json = JsonConvert.SerializeObject(new { ex.IdOperacion, ex.Mensaje, ex.Accion }, formatJson);
            }
            else
            {
                json = JsonConvert.SerializeObject(new { IdOperacion = System.Guid.NewGuid(), Mensaje = "Error no controlado", Accion = exception.ToString() }, formatJson);
            }
            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
