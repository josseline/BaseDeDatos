using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using BaseDeDatos.Models;

namespace BaseDeDatos.Repositorios
{
    public class PersonasRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<PersonaModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT * FROM Personas";

            if (sortBy == "NIFPERSONA")
            {
                consulta = consulta + " ORDER BY NIFPERSONA";
            }
            else if (sortBy == "NIFPERSONA DESC")
            {
                consulta = consulta + " ORDER BY NIFPERSONA DESC";
            }
            else if (sortBy == "Nombres")
            {
                consulta = consulta + " ORDER BY Nombres";
            }
            else if (sortBy == "Nombres DESC")
            {
                consulta = consulta + " ORDER BY Nombres DESC";
            }
            else if (sortBy == "Apellidos")
            {
                consulta = consulta + " ORDER BY Apellidos";
            }

            else if (sortBy == "Apellidos DESC")
            {
                consulta = consulta + " ORDER BY Apellidos DESC";
            }

            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<PersonaModelo>(consulta);
            }
        }

        public IEnumerable<PersonaModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM Personas ";
            IEnumerable<PersonaModelo> listaPersonas;
            var listaWhere = new List<string>();



            if (!String.IsNullOrWhiteSpace(criterio))
            {
                var parametros = new DynamicParameters();
                foreach (var palabra in criterio.Split(' '))
                {
                    var i = 0;
                    if (!String.IsNullOrWhiteSpace(palabra))
                    {
                        var nombre = "@criterio" + i;
                        var where = string.Format("NIFPERSONA LIKE {0} OR NOMBRES LIKE {0} OR APELLIDOS LIKE {0}", nombre);
                        listaWhere.Add(where);
                        parametros.Add(nombre, "%" + palabra + "%");
                        //listaPersonas = from p in listaPersonas
                        //                 where (
                        //                  p.NifPersona.Contains(palabra) ||
                        //                  p.Nombres.Contains(palabra) ||
                        //                  p.Apellidos.Contains(palabra)
                        //                  ) select p;
                    }

                    i++;
                }
                var nuevoWhere = String.Join("AND", listaWhere);
                consulta = consulta + " where " + nuevoWhere;
                using (var con = new SqlConnection(connectionString))
                {
                    listaPersonas = con.Query<PersonaModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listaPersonas = con.Query<PersonaModelo>(consulta);
                }
            }

            var resultado = listaPersonas.ToList();
            return resultado;

        }

        public PersonaModelo ObtenerUnica(string nif)
        {
            var consulta = "SELECT TOP 1 * FROM Personas WHERE NIFPERSONA = @nif";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<PersonaModelo>(consulta, new { nif }).FirstOrDefault();
            }
        }
        public void Crear(PersonaModelo modelo)
        {
            var consulta = "INSERT INTO Personas VALUES(@NifPersona, @Nombres, @Apellidos, @Direccion )";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.NifPersona, modelo.Nombres, modelo.Apellidos, modelo.Direccion });
            }
        }

        public void Editar(PersonaModelo modelo)
        {
            var consulta = "UPDATE Personas SET Nombres = @Nombres, Apellidos = @Apellidos, Direccion=@Direccion WHERE NIFPERSONA =@NifPersona";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombres, modelo.Apellidos, modelo.Direccion, modelo.NifPersona });
            }
        }

        public void Eliminar(string nif)
        {
            var consulta = "DELETE FROM Personas WHERE NIFPERSONA = @nif";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { nif });
            }
        }

        public bool ExisteNifPersona(string nifPersona)
        {
            var consulta = "SELECT * FROM Personas WHERE NIFPERSONA = @nifPersona";


            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<PersonaModelo>(consulta, new { nifPersona });
               
                if (resultado.Count() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

    }
}