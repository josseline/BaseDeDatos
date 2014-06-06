using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class CadenaEmisoraModelo
    {
        public int IdCadena { get; set; }
        public string NifEmisora { get; set; }
        public bool EsCentral { get; set; }
        public string NifPersona { get; set; }
        public string Cadena { get; set; }
        public string Emisora { get; set; }
        public string Director { get; set; }
    }
}