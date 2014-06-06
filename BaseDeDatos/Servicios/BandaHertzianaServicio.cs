using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class BandaHertzianaServicio
    {

        BandaHertzianaRepositorio bandaHertzianaRepositorio = new BandaHertzianaRepositorio();

        public IEnumerable<BandaHertzianaModelo> ObtenerTodas(string sortBy)
        {
            return bandaHertzianaRepositorio.ObtenerTodas(sortBy);
        }

        public BandaHertzianaModelo ObtenerUnica(int idBanda)
        {
            return bandaHertzianaRepositorio.ObtenerUnica(idBanda);
        }

        public void Crear(BandaHertzianaModelo modelo)
        {

            bandaHertzianaRepositorio.Crear(modelo);

        }

        public void Editar(BandaHertzianaModelo modelo)
        {
            bandaHertzianaRepositorio.Editar(modelo);

        }

        public void Eliminar(int idBanda)
        {
            bandaHertzianaRepositorio.Eliminar(idBanda);
        }
        public IEnumerable<BandaHertzianaModelo> ObtenerPorBusqueda(string criterio)
        {
            return bandaHertzianaRepositorio.ObtenerPorBusqueda(criterio);
        }
    }
}