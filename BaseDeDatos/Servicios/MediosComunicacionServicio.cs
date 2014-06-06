using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;


namespace BaseDeDatos.Servicios
{
    public class MediosComunicacionServicio
    {
        MediosComunicacionRepositorio medioComunicacionRepo = new MediosComunicacionRepositorio();

        public IEnumerable<MediosComunicacionModelo> ObtenerTodas(string sortBy)
        {
            return medioComunicacionRepo.ObtenerTodas(sortBy);
        }

        public MediosComunicacionModelo ObtenerUnica(string NoContrato)
        {
            return medioComunicacionRepo.ObtenerUnica(NoContrato);
        }

        public void Crear(MediosComunicacionModelo modelo)
        {

            medioComunicacionRepo.Crear(modelo);

        }

        public void Editar(MediosComunicacionModelo modelo)
        {
            medioComunicacionRepo.Editar(modelo);

        }

        public void Eliminar(string NIF)
        {
            medioComunicacionRepo.Eliminar(NIF);
        }

        public bool ExisteMedio(string nif)
        {
            return medioComunicacionRepo.ExisteMedio(nif);
        }
    }
}