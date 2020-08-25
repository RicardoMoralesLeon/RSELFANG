
using System;

namespace RSELFANG.TO
{
    public class ToSuDimco
    {
        /// <summary>
        /// Fecha
        /// </summary>
        public DateTime dim_fech { get; set; }
        /// <summary>
        /// Tipo Transacción
        /// </summary>
        public string dim_dtra { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public double dim_vtra { get; set; }
        /// <summary>
        /// Nombre operador
        /// </summary>
        public string pvr_noco { get; set; }
        /// <summary>
        /// Punto de Pago
        /// </summary>
        public string dpu_nopp { get; set; }
    }
}