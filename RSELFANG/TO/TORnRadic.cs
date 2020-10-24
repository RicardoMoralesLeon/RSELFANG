using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class TORnRadic
    {
        /// <summary>
        /// Lista Tipo Aportante
        /// </summary>
        public List<ArTiapo> artiapo { get; set; }
        /// <summary>
        /// Lista Paises
        /// </summary>
        public List<GnPaise> GnPaise { get; set; }
        /// <summary>
        /// Tipo de documento
        /// </summary>
        public List<GnTipdo> GnTipdo { get; set; }
        /// <summary>
        /// Identificación
        /// </summary>
        public List<ArApovo> arapovo { get; set; }
        /// <summary>
        /// Grupo de Radicacion
        /// </summary>
        public List<RnGrura> rngrura { get; set; }
        /// <summary>
        /// Parentesco
        /// </summary>
        public List<SuMpare> SuMpare { get; set; }
        /// <summary>
        /// Profesion
        /// </summary>
        public List<GnItem> gnprofe { get; set; }
        /// <summary>
        /// Condicion especial
        /// </summary>
        public List<GnItem> gnconde { get; set; }
        /// <summary>
        /// Clase de Trabajador
        /// </summary>
        public List<GnItem> clastra { get; set; }
        /// <summary>
        /// Tipo de Vinculación
        /// </summary>
        public List<GnItem> tipvinc { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public List<GnItem> cartrab { get; set; }
        ///// <summary>
        ///// Afiliados
        ///// </summary>
        //public List<SuAfili> SuAfili { get; set; }
        /// <summary>
        /// Digiflag SRN000001
        /// </summary>
        public string SRN000001 { get; set; }
        /// <summary>
        /// Digiflag SRN000002
        /// </summary>
        public string SRN000002 { get; set; }
        /// <summary>
        /// Centro de servicio
        /// </summary>
        public string cen_codi { get; set; }

    }
}