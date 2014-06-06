using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;
namespace BaseDeDatos.Servicios
{
    public class CadenaRadioServicio
    {
        CadenaRadioRepositorio cadenaRadioRepositorio = new CadenaRadioRepositorio();

        public IEnumerable<CadenaRadioModelo> ObtenerTodas(string sortBy)
        {
            return cadenaRadioRepositorio.ObtenerTodas(sortBy);
        }

        public CadenaRadioModelo ObtenerUnica(int idCadena)
        {
            return cadenaRadioRepositorio.ObtenerUnica(idCadena);
        }

        public void Crear(CadenaRadioModelo modelo)
        {

            cadenaRadioRepositorio.Crear(modelo);

        }

        public void Editar(CadenaRadioModelo modelo)
        {
            cadenaRadioRepositorio.Editar(modelo);

        }

        public void Eliminar(int idCadena)
        {
            cadenaRadioRepositorio.Eliminar(idCadena);
        }

        public IEnumerable<CadenaRadioModelo> ObtenerPorBusqueda(string criterio)
        {
            return cadenaRadioRepositorio.ObtenerPorBusqueda(criterio);
        }

    }
}