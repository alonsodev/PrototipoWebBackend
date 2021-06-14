using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Service.Rest.Dto.Base
{
    public class GenericSelectListItemDto
    {
        /// <summary>
        /// Código del parámetro.
        /// </summary>
        public string IdParametro { get; set; }
        public string PadreDetalleId { get; set; }
        

        /// <summary>
        /// Nombre del parámetro.
        /// </summary>
        public string NombreParametro { get; set; }

        /// <summary>
        /// Código del detalle de parámetro.
        /// </summary>
        public string Value { get; set; }

        public string ValorAdicional { get; set; }
        

        /// <summary>
        /// Nombre del detalle de parámetro.
        /// </summary>
        public string Text { get; set; }
        public int Orden { get; set; }

        /// <summary>
        /// Orden de un selector de detalles de parámetro cuando está asociado a otros selectores padre.
        /// </summary>
        public string OrdenPadre { get; set; }
    }
}
