using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Clone
{
    public static class CloneExtension<T> where T : class
    {
        public static T Clone(T obj)
        {
            return FastDeepCloner.DeepCloner.Clone(obj);
        }
    }
}
