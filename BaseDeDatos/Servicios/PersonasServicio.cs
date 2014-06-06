using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class PersonasServicio
    {
        PersonasRepositorio personasRepositorio = new PersonasRepositorio();

        public IEnumerable<PersonaModelo> ObtenerTodas(string sortBy)
        {
            return personasRepositorio.ObtenerTodas(sortBy);
        }

        public IEnumerable<PersonaModelo> ObtenerPorBusqueda(string criterio)
        {
            return personasRepositorio.ObtenerPorBusqueda(criterio);
        }
        public PersonaModelo ObtenerUnica(string nif)
        {
            return personasRepositorio.ObtenerUnica(nif);
        }

        public void Crear(PersonaModelo modelo)
        {

            personasRepositorio.Crear(modelo);

        }

        public void Editar(PersonaModelo modelo)
        {
            personasRepositorio.Editar(modelo);

        }

        public void Eliminar(string nif)
        {
            personasRepositorio.Eliminar(nif);
        }

        public bool ExisteNifPersona(string nif)
        {
            return personasRepositorio.ExisteNifPersona(nif);
        }
    }
}