using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class FranjaHorarioModelo
    {
        public int IdFranjaHorario { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string DiaSemana { get; set; }
    }
}