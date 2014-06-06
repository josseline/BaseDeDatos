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
    public class ProgramaRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<ProgramasModelo> ObtenerTodos(string sortBy)
        {
            var consulta = "SELECT pr.IdPrograma, pr.Nombre, CONCAT(pe.Nombres, ' ', pe.Apellidos) NombreCompleto, pr.NIFPERSONA  FROM Programas pr INNER JOIN Personas pe ON pr.NIFPERSONA = pe.NIFPERSONA";

            if (sortBy == "IdPrograma")
            {
                consulta = consulta + " ORDER BY IdPrograma";
            }
            else if (sortBy == "IdPrograma DESC")
            {
                consulta = consulta + " ORDER BY IdPrograma DESC";
            }
            else if (sortBy == "Nombre")
            {
                consulta = consulta + " ORDER BY Nombre";
            }
            else if (sortBy == "Nombre DESC")
            {
                consulta = consulta + " ORDER BY Nombre DESC";
            }
            else if (sortBy == "NombreCompleto")
            {
                consulta = consulta + " ORDER BY NombreCompleto";
            }
            else if (sortBy == "NombreCompleto DESC")
            {
                consulta = consulta + " ORDER BY NombreCompleto DESC";
            }
            else if (sortBy == "NIFPERSONA")
            {
                consulta = consulta + " ORDER BY NIFPERSONA";
            }
            else if (sortBy == "NIFPERSONA DESC")
            {
                consulta = consulta + " ORDER BY NIFPERSONA DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProgramasModelo>(consulta);
            }
        }

        public ProgramasModelo ObtenerUnico(int idPrograma)
        {
            var consulta = "SELECT TOP 1 * FROM Programas WHERE IdPrograma = @idPrograma";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProgramasModelo>(consulta, new { idPrograma }).FirstOrDefault();
            }
        }
        public void Crear(ProgramasModelo modelo)
        {
            var consulta = "INSERT INTO Programas VALUES(@Nombre, @NifPersona)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombre, modelo.NifPersona });
            }
        }

        public void Editar(ProgramasModelo modelo)
        {
            var consulta = "UPDATE Programas SET Nombre = @Nombre, NifPersona = @NifPersona WHERE IdPrograma =@IdPrograma";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombre, modelo.NifPersona, modelo.IdPrograma });
            }
        }

        public void Eliminar(int idPrograma)
        {
            var consulta = "DELETE FROM Programas WHERE IdPrograma = @IdPrograma";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { idPrograma });
            }
        }
        
        public IEnumerable<ProgramasModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM Programas ";
            IEnumerable<ProgramasModelo> listadoProgramas;
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
                        var where = string.Format("Nombre LIKE {0}", nombre);
                        listaWhere.Add(where);
                        parametros.Add(nombre, "%" + palabra + "%");
                    }

                    i++;
                }
                var nuevoWhere = String.Join("AND", listaWhere);
                consulta = consulta + " where " + nuevoWhere;
                using (var con = new SqlConnection(connectionString))
                {
                    listadoProgramas = con.Query<ProgramasModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listadoProgramas = con.Query<ProgramasModelo>(consulta);
                }
            }

            var resultado = listadoProgramas.ToList();
            return resultado;

        }

    }
}