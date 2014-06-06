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
    public class ContratoRepositorio
    {
         private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<ContratoModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT c.NoContrato, c.Duracion, p.Nombre  Patrocinador FROM Contrato c INNER JOIN Patrocinadores p ON c.NifPatrocinador = p.NifPatrocinador";

            if (sortBy == "NoContrato")
            {
                consulta = consulta + " ORDER BY NoContrato";
            }
            else if (sortBy == "NoContrato DESC")
            {
                consulta = consulta + " ORDER BY NoContrato DESC";
            }
            else if (sortBy == "Duracion")
            {
                consulta = consulta + " ORDER BY Duracion";
            }
            else if (sortBy == "Duracion DESC")
            {
                consulta = consulta + " ORDER BY Nombre Duracion";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ContratoModelo>(consulta);
            }
        }

        public ContratoModelo ObtenerUnica(string NoContrato)
        {
            var consulta = "SELECT TOP 1 * FROM Contrato WHERE NoContrato = @NoContrato";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ContratoModelo>(consulta, new { NoContrato }).FirstOrDefault();
            }
        }
        public void Crear(ContratoModelo modelo)
        {
            var consulta = "INSERT INTO Contrato VALUES(@NoContrato,@Duracion,@NifPatrocinador)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.NoContrato, modelo.Duracion, modelo.NifPatrocinador});
            }
        }

        public void Editar(ContratoModelo modelo)
        {
            var consulta = "UPDATE Contrato SET Duracion = @Duracion, NIFPatrocinador = @NifPatrocinador WHERE NoContrato =@NoContrato";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Duracion, modelo.NifPatrocinador, modelo.NoContrato});
            }
        }

        public void Eliminar(string NoContrato)
        {
            var consulta = "DELETE FROM Contrato WHERE NoContrato = @NoContrato";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { NoContrato });
            }
        }

        public bool ExisteContrato(string NoContrato)
        {
            var consulta = "SELECT * FROM Contrato WHERE NoContrato = @NoContrato";


            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<ContratoModelo>(consulta, new { NoContrato = NoContrato });

           
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
