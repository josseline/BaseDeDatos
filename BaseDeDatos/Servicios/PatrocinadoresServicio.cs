using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class PatrocinadoresServicio
    {
        PatrocinadoresRepositorio patrocinadoresRepositorio = new PatrocinadoresRepositorio();

        public IEnumerable<PatrocinadoresModelo> ObtenerTodas(string sortBy)
        {
            return patrocinadoresRepositorio.ObtenerTodos(sortBy);
        }

        public PatrocinadoresModelo ObtenerUnica(string nif)
        {
            return patrocinadoresRepositorio.ObtenerUnico(nif);
        }

        public void Crear(PatrocinadoresModelo modelo)
        {

            patrocinadoresRepositorio.Crear(modelo);

        }

        public void Editar(PatrocinadoresModelo modelo)
        {
            patrocinadoresRepositorio.Editar(modelo);

        }

        public void Eliminar(string nif)
        {
            patrocinadoresRepositorio.Eliminar(nif);
        }

        public bool ExisteNifPatrocinador(string nif)
        {
            return patrocinadoresRepositorio.ExisteNifPatrocinador(nif);
        }
        public IEnumerable<PatrocinadoresModelo> ObtenerPorBusqueda(string criterio)
        {
            return patrocinadoresRepositorio.ObtenerPorBusqueda(criterio);
        }
    }
}