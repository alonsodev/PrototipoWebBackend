using AutoMapper;

using ProtoWeb.Service.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;

using ProtoWeb.Service.Rest.Dto.Base;

using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;

namespace ProtoWeb.Service.Rest.MainContext.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, Dto.Cliente.ClienteDto>().ReverseMap();
            CreateMap<ClienteReadOnly, Dto.Cliente.ClienteDto>().ReverseMap();
            CreateMap<FiltroCliente, Dto.Cliente.FiltroClienteDto>().ReverseMap();
            CreateMap<ClienteReadOnly, Dto.Cliente.ClienteDto>().ReverseMap();
            CreateMap<ClienteReadOnly, Dto.Cliente.GetListClienteResultDto>().ReverseMap();
            CreateMap<Cliente, Dto.Cliente.RegisterClienteDto>().ReverseMap();
            CreateMap<Cliente, Dto.Cliente.RegisterClienteResultDto>().ReverseMap();
            CreateMap<Cliente, Dto.Cliente.RegisterClienteDto>().ReverseMap();
            CreateMap<Cliente, Dto.Cliente.UpdateClienteDto>().ReverseMap();
            CreateMap<Cliente, Dto.Cliente.UpdateClienteResultResultDto>().ReverseMap();


        }
    }
}
