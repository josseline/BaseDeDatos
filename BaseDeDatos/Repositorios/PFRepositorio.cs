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
    public class PFRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<ProgramaFranjaModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT pf.IdCorrelativo, pr.Nombre NombrePrograma, CONCAT(fh.HoraInicio, ' - ', fh.HoraFin, ' - ', fh.DiaSemana) FranjaHorarioDescripcion  FROM ProgramaFranja pf INNER JOIN Programas pr ON pr.IdPrograma = pf.IdPrograma INNER JOIN FranjaHorario fh ON fh.IdFranjaHorario = pf.IdFranjaHorario ";

            if (sortBy == "IdPrograma")
            {
                consulta = consulta + " ORDER BY IdPrograma";
            }
            else if (sortBy == "IdPrograma DESC")
            {
                consulta = consulta + " ORDER BY IdPrograma DESC";
            }
            else if (sortBy == "IdFranjaHorario")
            {
                consulta = consulta + " ORDER BY IdFranjaHorario";
            }
            else if (sortBy == "IdFranjaHorario DESC")
            {
                consulta = consulta + " ORDER BY IdFranjaHorario DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProgramaFranjaModelo>(consulta);
            }
        }

        public ProgramaFranjaModelo ObtenerUnica(int IdCorrelativo)
        {
            var consulta = "SELECT TOP 1 * FROM ProgramaFranja WHERE IdCorrelativo = @IdCorrelativo";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProgramaFranjaModelo>(consulta, new { IdCorrelativo}).FirstOrDefault();
            }
        }
        public void Crear(ProgramaFranjaModelo modelo)
        {
            var consulta = "INSERT INTO ProgramaFranja VALUES(@IdPrograma,@IdFranjaHorario)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.IdPrograma, modelo.IdFranjaHorario });
            }
        }

        public void Editar (ProgramaFranjaModelo modelo)
        {
            var consulta = "UPDATE ProgramaFranja SET IdPrograma = @IdPrograma, IdFranjaHorario = @IdFranjaHorario WHERE IdCorrelativo =@IdCorrelativo";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.IdPrograma, modelo.IdFranjaHorario, modelo.IdCorrelativo });
            }
        }
        public void Eliminar(int IdCorrelativo)
        {
            var consulta = "DELETE FROM ProgramaFranja WHERE IdCorrelativo = @IdCorrelativo";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { IdCorrelativo });
            }
        }
        public IEnumerable<ProgramaFranjaModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM PROGRAMAFRANJA ";
            IEnumerable<ProgramaFranjaModelo> listadoEmisoras;
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
                        var where = string.Format("DiaSemana LIKE {0}", nombre);
                        listaWhere.Add(where);
                        parametros.Add(nombre, "%" + palabra + "%");
                    }

                    i++;
                }
                var nuevoWhere = String.Join("AND", listaWhere);
                consulta = consulta + " where " + nuevoWhere;
                using (var con = new SqlConnection(connectionString))
                {
                    listadoEmisoras = con.Query<ProgramaFranjaModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listadoEmisoras = con.Query<ProgramaFranjaModelo>(consulta);
                }
            }

            var resultado = listadoEmisoras.ToList();
            return resultado;

        }
    }
}