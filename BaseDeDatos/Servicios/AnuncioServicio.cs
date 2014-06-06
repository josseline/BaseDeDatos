using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class AnuncioServicio
    {
        AnuncioRepositorio cadenaAnuncioRepositorio = new AnuncioRepositorio();

        public IEnumerable<AnuncioModelo> ObtenerTodas(string sortBy)
        {
            return cadenaAnuncioRepositorio.ObtenerTodas(sortBy);
        }

        public AnuncioModelo ObtenerUnica(int IdAnuncio)
        {
            return cadenaAnuncioRepositorio.ObtenerUnica(IdAnuncio);
        }

        public void Crear(AnuncioModelo modelo)
        {

            cadenaAnuncioRepositorio.Crear(modelo);

        }

        public void Editar(AnuncioModelo modelo)
        {
            cadenaAnuncioRepositorio.Editar(modelo);

        }

        public void Eliminar(int IdAnuncio)
        {
            cadenaAnuncioRepositorio.Eliminar(IdAnuncio);
        }
    }
}