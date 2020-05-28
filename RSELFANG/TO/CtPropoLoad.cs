using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.TO
{
    public class CtPropoLoad
    {
        /// <summary>
        /// Tipo de documento
        /// </summary>
        public List<GnTipdo> tipdoct { get; set; }
        /// <summary>
        /// Camara de comercio
        /// </summary>
        public List<TOCtCamar> CtCamar { get; set; }
        /// <summary>
        /// Tipo de Contratista
        /// </summary>
        public List<GnItem> tipCont { get; set; }
        /// <summary>
        /// Lista Paises
        /// </summary>
        public List<GnPaise> GnPaise { get; set; }
        /// <summary>
        /// Lista Regiones
        /// </summary>
        public List<GnRegio> GnRegio { get; set; }
        /// <summary>
        /// Lista Departamentos
        /// </summary>
        public List<GnDepar> GnDepar { get; set; }
        /// <summary>
        /// Lista Municipios
        /// </summary>
        public List<GnMunic> GnMunic { get; set; }
        /// <summary>
        /// Lista Localidades
        /// </summary>
        public List<GnLocal> GnLocal { get; set; }
        /// <summary>
        /// Lista Barrios
        /// </summary>
        public List<GnBarri> GnBarri { get; set; }
        /// <summary>
        /// Lista Actividades
        /// </summary>
        public List<GnArbol> GnArbol { get; set; }

        /// <summary>
        /// Politica de tratamiento de datos
        /// </summary>
        public string parptda { get; set; }

        /// <summary>
        /// Proteccion de Datos
        /// </summary>
        public List<GnItem> CtDtrda { get; set; }

        /// <summary>
        /// Párametro Información de Proveedores
        /// </summary>
        public string parcrpr { get; set; }
        
        /// <summary>
        /// Imagen de empresa
        /// </summary>        
        public byte[] empImage { get; set; }

        /// <summary>
        /// Manejar Nomenclatura DIAN en Campos de Dirrección
        /// </summary>
        public string SGN000008 { get; set; }
    }
}