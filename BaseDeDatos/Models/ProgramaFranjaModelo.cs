using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class ProgramaFranjaModelo
    {
        public int IdCorrelativo { get; set; }
        public int IdPrograma { get; set; }
        public int IdFranjaHorario { get; set; }
        public string NombrePrograma { get; set; }
        public string FranjaHorarioDescripcion { get; set; }
    }
}