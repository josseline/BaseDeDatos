using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDeDatos.Models
{
    public class EmisorasModelo
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public int IdBandaHertziana { get; set; }
        public int IdProvincia { get; set; }
        public int IdPrograma { get; set; }
    }
}