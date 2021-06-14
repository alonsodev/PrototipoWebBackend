using AutoMapper;
using ProtoWeb.Infra.CrossCutting.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Adapter
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {
        IMapper mapper = null;

        public AutoMapperTypeAdapterFactory()
        {
            var tipos = new List<Type>();
            string[] assembliesAsArray = { "ProtoWeb.Service.Rest.MainContext" };
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p => assembliesAsArray.Contains(p.GetName().Name)).ToList();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.BaseType == typeof(Profile)) tipos.Add(type);
                }
            }
            var profile = new AutoMapper.Configuration.MapperConfigurationExpression();
            foreach (var tipo in tipos)
            {
                profile.AddProfile(Activator.CreateInstance(tipo) as Profile);
            }

            var mapperConfig = new MapperConfiguration(profile);
            mapper = mapperConfig.CreateMapper();
        }

        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter(mapper);
        }
    }
}
