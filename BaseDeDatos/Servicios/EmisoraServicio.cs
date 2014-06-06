using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class EmisoraServicio
    {
        EmisoraRepositorio emisoraRepositorio= new EmisoraRepositorio();

        public IEnumerable<EmisorasModelo> ObtenerTodas(string sortBy)
        {
            return emisoraRepositorio.ObtenerTodas(sortBy);
        }

        public EmisorasModelo ObtenerUnica(string NIF)
        {
            return emisoraRepositorio.ObtenerUnica(NIF);
        }

        public void Crear(EmisorasModelo modelo)
        {

            emisoraRepositorio.Crear(modelo);

        }

        public void Editar(EmisorasModelo modelo)
        {
            emisoraRepositorio.Editar(modelo);

        }

        public void Eliminar(int IdAnuncio)
        {
            emisoraRepositorio.Eliminar(IdAnuncio);
        }
        public IEnumerable<EmisorasModelo> ObtenerPorBusqueda(string criterio)
        {
            return emisoraRepositorio.ObtenerPorBusqueda(criterio);
        }

        public bool ExisteEmisora(string nifEmisora)
        {
            return emisoraRepositorio.ExisteEmisora(nifEmisora);
        }
    }
}