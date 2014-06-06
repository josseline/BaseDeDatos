using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class ProgramasModelo
    {
        public int IdPrograma { get; set; }
        public string Nombre { get; set; }
        public string NifPersona { get; set; }
        public string NombreCompleto { get; set; }
    }
}