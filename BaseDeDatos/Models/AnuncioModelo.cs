using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class AnuncioModelo
    {
        public int IdAnuncio { get; set; }
        public int IdPrograma { get; set; }
        public string NombrePrograma { get; set; }
        public string NifPatrocinador { get; set; }
        public string NombrePatrocinador { get; set; }
        public int DuracionAnuncio { get; set; }
        public decimal PrecioPorSegundo { get; set; }
    }
}