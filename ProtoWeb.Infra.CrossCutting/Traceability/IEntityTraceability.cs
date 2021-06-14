using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Traceability
{
    public interface IEntityTraceability
    {
        TTarget BuildTraceability<TTarget>(
                object sourceObject,
                string text,
                string parentEntityTypeId = null,
                string parentEntityId = null)
            where TTarget : class, new();

        TTarget BuildTraceability<TTarget>(
                object updatedObject,
                object originalObject,
                string text,
                string parentEntityTypeId = null,
                string parentEntityId = null,
                string entityTypeId = null)
            where TTarget : class, new();
    }
}
