using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;

namespace BaseDeDatos.Servicios
{
    public class ProvinciaServicio
    {
        ProvinciasRepositorio provinciaRepositorio = new ProvinciasRepositorio();

        public IEnumerable<ProvinciaModelo> ObtenerTodas(string sortBy)
        {
            return provinciaRepositorio.ObtenerTodas(sortBy);
        }

        public ProvinciaModelo ObtenerUnica(int idProvincia)
        {
            return provinciaRepositorio.ObtenerUnica(idProvincia);
        }

        public void Crear (ProvinciaModelo modelo){

            provinciaRepositorio.Crear(modelo);

        }

        public void Editar(ProvinciaModelo modelo)
        {
            provinciaRepositorio.Editar(modelo);

        }

        public void Eliminar(int idProvincia)
        {
            provinciaRepositorio.Eliminar(idProvincia);
        }
        public IEnumerable<ProvinciaModelo> ObtenerPorBusqueda(string criterio)
        {
            return provinciaRepositorio.ObtenerPorBusqueda(criterio);
        }
    }
}