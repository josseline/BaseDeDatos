using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;


namespace BaseDeDatos.Servicios
{
    public class PFServicio
    {
        PFRepositorio PfRepositorio = new PFRepositorio();

        public IEnumerable<ProgramaFranjaModelo> ObtenerTodas(string sortBy)
        {
            return PfRepositorio.ObtenerTodas(sortBy);
        }

        public ProgramaFranjaModelo ObtenerUnica(int idCorrelativo)
        {
            return PfRepositorio.ObtenerUnica(idCorrelativo);
        }

        public void Crear(ProgramaFranjaModelo modelo)
        {
            PfRepositorio.Crear(modelo);
        }

        public void Editar(ProgramaFranjaModelo modelo)
        {
            PfRepositorio.Editar(modelo);
        }

        public void Eliminar(int IdCorrelativo)
        {
            PfRepositorio.Eliminar(IdCorrelativo);
        }

        public IEnumerable<ProgramaFranjaModelo> ObtenerPorBusqueda(string criterio)
        {
            return PfRepositorio.ObtenerPorBusqueda(criterio);
        }

    }
}