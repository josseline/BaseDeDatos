using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class FranjaHorarioServicio
    {
        FranjaHorarioRepositorio franjaHorarioRepositorio = new FranjaHorarioRepositorio();

        public IEnumerable<FranjaHorarioModelo> ObtenerTodas(string sortBy)
        {
            return franjaHorarioRepositorio.ObtenerTodas(sortBy);
        }

        public FranjaHorarioModelo ObtenerUnica(int idFranja)
        {
            return franjaHorarioRepositorio.ObtenerUnica(idFranja);
        }

        public void Crear(FranjaHorarioModelo modelo)
        {

            franjaHorarioRepositorio.Crear(modelo);

        }

        public void Editar(FranjaHorarioModelo modelo)
        {
            franjaHorarioRepositorio.Editar(modelo);

        }

        public void Eliminar(int idFranja)
        {
            franjaHorarioRepositorio.Eliminar(idFranja);
        }
        public IEnumerable<FranjaHorarioModelo> ObtenerPorBusqueda(string criterio)
        {
            return franjaHorarioRepositorio.ObtenerPorBusqueda(criterio);
        }

    }
}