using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseDeDatos.Controllers
{
    public class PersonasController : ApiController
    {

        private readonly PersonasServicio servicio;

        public PersonasController()
        {
            this.servicio = new PersonasServicio();
        }

        public IHttpActionResult Get(string sortBy = null, string criterio = null)
        {
            IEnumerable<PersonaModelo> result;

            if (!string.IsNullOrWhiteSpace(criterio))
            {
                result = servicio.ObtenerPorBusqueda(criterio);
            }
            else
            {
                result = servicio.ObtenerTodas(sortBy);
            }

            return Ok(result);            
        }

        public IHttpActionResult Get(string id)
        {
            var result = servicio.ObtenerUnica(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        public IHttpActionResult Post(PersonaModelo modelo)
        {
            if (modelo == null)
            {
                return BadRequest("Debe especificar un modelo");
            }

            servicio.Crear(modelo);
            return Created(Url.Link("DefaultApi", new { id = modelo.NifPersona }), modelo);
        }

        public IHttpActionResult Put(string id, PersonaModelo modelo)
        {
            if (modelo == null)
            {
                return BadRequest("Debe especificar un modelo");
            }

            if (!servicio.ExisteNifPersona(id))
            {
                return NotFound();
            }

            modelo.NifPersona = id;
            servicio.Editar(modelo);

            return this.Ok(modelo);
        }

        public IHttpActionResult Delete(string id)
        {

            if (!servicio.ExisteNifPersona(id))
            {
                return NotFound();
            }

            servicio.Eliminar(id);
            return Ok();
        }
    }
}
