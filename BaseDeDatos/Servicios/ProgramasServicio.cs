using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class ProgramasServicio
    {
        ProgramaRepositorio programaRepositorio = new ProgramaRepositorio();

        public IEnumerable<ProgramasModelo> ObtenerTodas(string sortBy)
        {
            return programaRepositorio.ObtenerTodos(sortBy);
        }

        public ProgramasModelo ObtenerUnica(int idPrograma)
        {
            return programaRepositorio.ObtenerUnico(idPrograma);
        }

        public void Crear(ProgramasModelo modelo)
        {

            programaRepositorio.Crear(modelo);

        }

        public void Editar(ProgramasModelo modelo)
        {
            programaRepositorio.Editar(modelo);

        }

        public void Eliminar(int idPrograma)
        {
            programaRepositorio.Eliminar(idPrograma);
        }
        public IEnumerable<ProgramasModelo> ObtenerPorBusqueda(string criterio)
        {
            return programaRepositorio.ObtenerPorBusqueda(criterio);
        }
    }
}