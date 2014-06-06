using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;
namespace BaseDeDatos.Servicios
{
    public class CadenaEmisoraServicio
    {
        CadenaEmisoraRepositorio cadenaEmisoraRepositorio = new CadenaEmisoraRepositorio();

        public IEnumerable<CadenaEmisoraModelo> ObtenerTodas(string sortBy)
        {
            return cadenaEmisoraRepositorio.ObtenerTodas(sortBy);
        }

        public CadenaEmisoraModelo ObtenerUnica(int idCadena, string nifEmisora)
        {
            return cadenaEmisoraRepositorio.ObtenerUnica(idCadena, nifEmisora);
        }

        public void Crear(CadenaEmisoraModelo modelo)
        {
            cadenaEmisoraRepositorio.Crear(modelo);
        }

        public void Editar(CadenaEmisoraModelo modelo)
        {
            cadenaEmisoraRepositorio.Editar(modelo);
        }

        public void Eliminar(int IdCadena, string NifEmisora)
        {
            cadenaEmisoraRepositorio.Eliminar(IdCadena, NifEmisora);
        }

        public bool ExisteCadenaEmisora(int IdCadena, string NifEmisora)
        {
            return cadenaEmisoraRepositorio.ExisteCadenaEmisora(IdCadena, NifEmisora);
        }


    }

}