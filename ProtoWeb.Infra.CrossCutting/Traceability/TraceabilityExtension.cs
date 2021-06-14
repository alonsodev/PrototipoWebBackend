using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Traceability
{
    public static class TraceabilityExtension
    {
        public static TEntity BuildTraceability<TEntity>(
                this object sourceObject,
                string text,
                string parentEntityTypeId = null,
                string parentEntityId = null,
                string entityTypeId = null) where TEntity : class, new()
        {
            var adapter = EntityTraceabilityFactory.CreateAdapter();
            return adapter.BuildTraceability<TEntity>(sourceObject, text, parentEntityTypeId, parentEntityId);
        }

        public static TEntity BuildTraceability<TEntity>(
            this object updatedObject,
            object originalObject, 
            string text, 
            string parentEntityTypeId = null,
            string parentEntityId = null,
            string entityTypeId = null) where TEntity : class, new()
        {
            var adapter = EntityTraceabilityFactory.CreateAdapter();
            return adapter.BuildTraceability<TEntity>(updatedObject, originalObject, text, parentEntityTypeId, parentEntityId, entityTypeId);
        }
    }
}