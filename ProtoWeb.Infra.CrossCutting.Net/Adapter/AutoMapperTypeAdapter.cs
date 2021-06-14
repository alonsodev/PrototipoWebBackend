using AutoMapper;
using ProtoWeb.Infra.CrossCutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static ProtoWeb.Infra.CrossCutting.Net.Constantes.ConstantesDb;

namespace ProtoWeb.Infra.CrossCutting.Net.Adapter
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        readonly IMapper _mapper;

        public AutoMapperTypeAdapter(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return _mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return _mapper.Map<TTarget>(source);
        }
    }
}
