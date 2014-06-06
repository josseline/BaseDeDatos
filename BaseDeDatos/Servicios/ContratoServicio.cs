using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Models;

namespace BaseDeDatos.Servicios
{
    public class ContratoServicio
    {
        ContratoRepositorio contratoRepo = new ContratoRepositorio();

        public IEnumerable<ContratoModelo> ObtenerTodas(string sortBy)
        {
            return contratoRepo.ObtenerTodas(sortBy);
        }

        public ContratoModelo ObtenerUnica(string NoContrato)
        {
            return contratoRepo.ObtenerUnica(NoContrato);
        }

        public void Crear(ContratoModelo modelo)
        {

            contratoRepo.Crear(modelo);

        }

        public void Editar(ContratoModelo modelo)
        {
            contratoRepo.Editar(modelo);

        }

        public void Eliminar(string NoContrato)
        {
            contratoRepo.Eliminar(NoContrato);
        }

        public bool ExisteContrato(string NoContrato)
        {
            return contratoRepo.ExisteContrato(NoContrato);
        }
    }
}