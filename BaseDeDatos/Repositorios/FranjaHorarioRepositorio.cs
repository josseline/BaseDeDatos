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
    public class FranjaHorarioRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<FranjaHorarioModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT * FROM FranjaHorario";

            if (sortBy == "IdFranjaHorario")
            {
                consulta = consulta + " ORDER BY IdFranjaHorario";
            }
            else if (sortBy == "IdFranjaHorario DESC")
            {
                consulta = consulta + " ORDER BY IdFranjaHorario DESC";
            }
            else if (sortBy == "DiaSemana")
            {
                consulta = consulta + " ORDER BY DiaSemana";
            }
            else if (sortBy == "DiaSemana DESC")
            {
                consulta = consulta + " ORDER BY DiaSemana DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<FranjaHorarioModelo>(consulta);
            }
        }

        public FranjaHorarioModelo ObtenerUnica(int idFranja)
        {
            var consulta = "SELECT TOP 1 * FROM FranjaHorario WHERE IdFranjaHorario = @idFranja";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<FranjaHorarioModelo>(consulta, new { idFranja }).FirstOrDefault();
            }
        }
        public void Crear(FranjaHorarioModelo modelo)
        {
            var consulta = "INSERT INTO FranjaHorario VALUES(@HoraInicio, @HoraFin, @DiaSemana)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.HoraInicio, modelo.HoraFin, modelo.DiaSemana });
            }
        }

        public void Editar(FranjaHorarioModelo modelo)
        {
            var consulta = "UPDATE FranjaHorario SET HoraInicio = @HoraInicio, HoraFin = @HoraFin, DiaSemana=@DiaSemana WHERE IdFranjaHorario =@IdFranjaHorario";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.HoraInicio, modelo.HoraFin, modelo.DiaSemana, modelo.IdFranjaHorario });
            }
        }

        public void Eliminar(int idFranja)
        {
            var consulta = "DELETE FROM FranjaHorario WHERE IdFranjaHorario = @idFranja";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { idFranja });
            }
        }
        public IEnumerable<FranjaHorarioModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM FranjaHorario ";
            IEnumerable<FranjaHorarioModelo> listadoEmisoras;
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
                    listadoEmisoras = con.Query<FranjaHorarioModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listadoEmisoras = con.Query<FranjaHorarioModelo>(consulta);
                }
            }

            var resultado = listadoEmisoras.ToList();
            return resultado;

        }
    }
}