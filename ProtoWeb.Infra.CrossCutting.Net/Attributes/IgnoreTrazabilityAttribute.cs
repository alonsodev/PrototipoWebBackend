using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Net.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnoreTrazabilityAttribute : Attribute
    {
        public bool Ignore { get; set; }

        public IgnoreTrazabilityAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }
}
