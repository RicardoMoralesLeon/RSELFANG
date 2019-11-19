﻿using System.Collections.Generic;

namespace RSELFANG.TO
{
    public class PqTrazab
    {
        /// <summary>
        /// Seccional
        /// </summary>
        public List<GnArbol> seccional { get; set; }
        /// <summary>
        /// Forma de Recibido
        /// </summary>
        public List<GnItem> formRecib { get; set; }
        /// <summary>
        /// Tipo PQR
        /// </summary>
        public List<GnItem> tipoDePqr { get; set; }
        /// <summary>
        /// Area responsable
        /// </summary>
        public List<GnArbol> areaRespo { get; set; }
        /// <summary>
        /// Tipipificación
        /// </summary>
        public List<GnItem> tipificac { get; set; }
        /// <summary>
        /// Subtipipificación
        /// </summary>
        public List<GnItem> subtipifi { get; set; }
        /// <summary>
        /// Grupo pertenece
        /// </summary>
        public List<TOGPerte> grupPerte { get; set; }
    }
}