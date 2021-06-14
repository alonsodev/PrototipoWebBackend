using ProtoWeb.Infra.CrossCutting.Net.Attributes;
using ProtoWeb.Infra.CrossCutting.Traceability;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using static ProtoWeb.Infra.CrossCutting.Net.Constantes.ConstantesDb;

namespace ProtoWeb.Infra.CrossCutting.Net.Traceability
{
    public class ReflectionTraceability : IEntityTraceability
    {

        public ReflectionTraceability()
        {

        }

        public TTarget BuildTraceability<TTarget>(
            object sourceObject,
            string text,
            string parentEntityTypeId = null,
            string parentEntityId = null) where TTarget : class, new()
        {
            var traceability = (TTarget)Activator.CreateInstance(typeof(TTarget)); // Crea un objeto trazabilidad vacío.
            string entityTypeId = typeof(TipoEntidad).GetField(sourceObject.GetType().Name).GetValue(null).ToString(); // Obtiene el tipo de entidad del objeto origen.
            string entityId = sourceObject.GetType().GetProperty("Id").GetValue(sourceObject).ToString(); // Obtiene el id del objeto origen.

            #region Llena el objeto trazabilidad
            traceability.GetType().GetProperty("Texto").SetValue(traceability, text);
            traceability.GetType().GetProperty("TipoEntidadPadreId").SetValue(traceability, (parentEntityTypeId == null) ? entityTypeId : parentEntityTypeId);
            traceability.GetType().GetProperty("EntidadPadreId").SetValue(traceability, (parentEntityId == null) ? entityId : parentEntityId.ToString());
            traceability.GetType().GetProperty("TipoEntidadId").SetValue(traceability, entityTypeId);
            traceability.GetType().GetProperty("EntidadId").SetValue(traceability, entityId);
            #endregion

            return traceability;
        }

        public TTarget BuildTraceability<TTarget>(
            object updatedObject,
            object originalObject,
            string text,
            string parentEntityTypeId = null,
            string parentEntityId = null,
            string entityTypeId = null) where TTarget : class, new()
        {
            var traceability = (TTarget)Activator.CreateInstance(typeof(TTarget)); // Crea un objeto trazabilidad vacío.
            entityTypeId = typeof(TipoEntidad).GetField(updatedObject.GetType().Name)?.GetValue(null).ToString() ?? entityTypeId; // Obtiene el tipo de entidad del objeto origen.
            string entityId = updatedObject.GetType().GetProperty("Id").GetValue(updatedObject).ToString(); // Obtiene el id del objeto origen.

            #region Llena el objeto trazabilidad
            traceability.GetType().GetProperty("Texto").SetValue(traceability, text);
            traceability.GetType().GetProperty("TipoEntidadPadreId").SetValue(traceability, (parentEntityTypeId == null) ? entityTypeId : parentEntityTypeId);
            traceability.GetType().GetProperty("EntidadPadreId").SetValue(traceability, (parentEntityId == null) ? entityId : parentEntityId.ToString());
            traceability.GetType().GetProperty("TipoEntidadId").SetValue(traceability, entityTypeId);
            traceability.GetType().GetProperty("EntidadId").SetValue(traceability, entityId);
            #endregion

            MethodInfo addTraceabilityDetail = traceability.GetType().GetMethod("RegistrarTrazabilidadDetalle");
            ParameterInfo[] pars = addTraceabilityDetail.GetParameters();
            List<Variance> variances = new List<Variance>();
            PropertyInfo[] fi = updatedObject.GetType().GetProperties();

            for (int i = 0; i < fi.Length; i++)
            {
                Variance v = new Variance();
                v.Property = fi[i].Name;
                v.PropertyType = fi[i].PropertyType.Name;
                v.originalValue = originalObject.GetType().GetProperty(fi[i].Name).GetValue(originalObject)?.ToString();
                v.updatedValue = updatedObject.GetType().GetProperty(fi[i].Name).GetValue(updatedObject)?.ToString();
                var fieldIgnore = fi[i].GetCustomAttributes(typeof(IgnoreTrazabilityAttribute), false);

                ParseProperty(ref v);

                var isIgnore = (fieldIgnore.Length == 0) ? false : (fieldIgnore[0] as IgnoreTrazabilityAttribute).Ignore;
                if (!isIgnore)
                {
                    // if (v.originalValue != null && v.updatedValue != null && !v.originalValue.Equals(v.updatedValue))
                    if (!Object.Equals(v.originalValue, v.updatedValue))
                    {
                        var displayNameAttribute = fi[i].GetCustomAttributes(typeof(DisplayNameAttribute), false);
                        var displayName = (displayNameAttribute.Length == 0) ? v.Property : (displayNameAttribute[0] as DisplayNameAttribute).DisplayName;
                        object[] parametersArray = new object[4]
                        {
                            v.Property,
                            displayName,
                            (v.originalValue == null) ? String.Empty : v.originalValue.ToString(),
                            (v.updatedValue == null) ? String.Empty : v.updatedValue.ToString()
                        };
                        traceability.GetType().GetProperty("HayCambios").SetValue(traceability, true);
                        addTraceabilityDetail.Invoke(traceability, parametersArray);
                    }  
                }
            }

            return traceability;
        }

        private void ParseProperty(ref Variance variance)
        {
            if (variance.PropertyType.Equals("Decimal"))
            {
                if (decimal.Parse(variance.originalValue.ToString()) == 0 && decimal.Parse(variance.updatedValue.ToString()) == 0)
                {
                    variance.originalValue = 0;
                    variance.updatedValue = 0;
                }
            }
        }
    }
}
