﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.DTO
{
    /// <summary>
    /// Clase utilizada para representar un correo electronico.
    /// </summary>
    public class CorreoDTO
    {
        /// <summary>
        /// Atributo ID.
        /// </summary>
        private int iId;

        /// <summary>
        /// Atributo fecha.
        /// </summary>
        private DateTime iFecha;

        /// <summary>
        /// Atributo tipoCorreo.
        /// </summary>
        private string iTipoCorreo;

        /// <summary>
        /// Atributo texto.
        /// </summary>
        private string iTexto;

        /// <summary>
        /// Atributo origen.
        /// </summary>
        private string iCuentaOrigen;      

        /// <summary>
        /// Atributo destino.
        /// </summary>
        private string iCuentaDestino;

        /// <summary>
        /// Atributo asunto.
        /// </summary>
        private string iAsunto;

        /// <summary>
        /// Atributo leido.
        /// </summary>
        private int iLeido;

        /// <summary>
        /// Constructor de una instancia de la clase Correo .
        /// </summary>
        public CorreoDTO() {}

        /// <summary>
        /// Constructor de una instancia de la clase Correo .
        /// </summary>
        public CorreoDTO(int pId, DateTime pFecha, string pTipoCorreo, string pTexto, string pCuentaOrigen, string pCuentaDestino, string pAsunto, int pLeido) 
        {
            iId = pId;
            iFecha = pFecha;
            iTipoCorreo = pTipoCorreo;
            iTexto = pTexto;
            iCuentaOrigen = pCuentaOrigen;
            iCuentaDestino = pCuentaDestino;
            iAsunto = pAsunto;
            iLeido = pLeido;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return "falta desarrollar el metodo";
        }

        /// <summary>
        /// Propiedad de lectura y escritura del ID.
        /// </summary>
        public int Id
        {
            get { return this.iId; }
            set { this.iId = value; }
        }
        
        /// <summary>
        /// Propiedad de lectura y escritura de la Fecha.
        /// </summary>
        public DateTime Fecha
        {
            get { return this.iFecha; }
            set { this.iFecha = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de la Hora.
        /// </summary>
        public string TipoCorreo
        {
            get { return this.iTipoCorreo; }
            set { this.iTipoCorreo = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Texto.
        /// </summary>
        public string Texto
        {
            get { return this.iTexto; }
            set { this.iTexto = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Origen.
        /// </summary>
        public string CuentaOrigen
        {
            get { return this.iCuentaOrigen; }
            set { this.iCuentaOrigen = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Destino.
        /// </summary>
        public string CuentaDestino
        {
            get { return this.iCuentaDestino; }
            set { this.iCuentaDestino = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Asunto.
        /// </summary>
        public string Asunto
        {
            get { return this.iAsunto; }
            set { this.iAsunto = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo leído.
        /// </summary>
        public int Leido
        {
            get { return this.iLeido; }
            set { this.iLeido = value; }
        }
    }
}
