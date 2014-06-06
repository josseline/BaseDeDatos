using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class ContratoModelo
    {
        public string NoContrato { get; set; }
        public int Duracion { get; set; }
        public string NifPatrocinador { get; set; }
        public string Patrocinador { get; set; }
    }
}