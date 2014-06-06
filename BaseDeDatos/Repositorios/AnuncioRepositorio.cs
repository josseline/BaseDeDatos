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
    public class AnuncioRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<AnuncioModelo> ObtenerTodas(string sortBy)
        {
            var consulta = @"SELECT An.IdAnuncio, An.IdPrograma, pr.Nombre NombrePrograma, pa.Nombre NombrePatrocinador
                                FROM Anuncio An
                                INNER JOIN PROGRAMAS pr ON An.IdPrograma = pr.IdPrograma INNER JOIN PATROCINADORES pa on An.NifPatrocinador = pa.NifPatrocinador";

            if (sortBy == "IdAnuncio")
            {
                consulta = consulta + " ORDER BY An.IdAnuncio";
            }
            else if (sortBy == "IdAnuncio DESC")
            {
                consulta = consulta + " ORDER BY An.IdAnuncio DESC";
            }
            if (sortBy == "NombrePrograma")
            {
                consulta = consulta + " ORDER BY NombrePrograma";
            }
            else if (sortBy == "NombrePrograma DESC")
            {
                consulta = consulta + " ORDER BY NombrePrograma DESC";
            }
            else if (sortBy == "NombrePatrocinador")
            {
                consulta = consulta + " ORDER BY NombrePatrocinador";
            }
            else if (sortBy == "NombrePatrocinador DESC")
            {
                consulta = consulta + " ORDER BY NombrePatrocinador DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<AnuncioModelo>(consulta);
            }
        }

        public AnuncioModelo ObtenerUnica(int IdAnuncio)
        {
            var consulta = @"SELECT An.IdAnuncio, An.IdPrograma, pr.Nombre NombrePrograma, pa.Nombre NombrePatrocinador, an.DuracionAnuncio, an.PrecioPorSegundo, pa.NifPatrocinador
                                FROM Anuncio An
                                INNER JOIN PROGRAMAS pr ON An.IdPrograma = pr.IdPrograma INNER JOIN PATROCINADORES pa on An.NifPatrocinador = pa.NifPatrocinador WHERE IdAnuncio = @IdAnuncio";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<AnuncioModelo>(consulta, new { IdAnuncio }).FirstOrDefault();
            }
        }
        public void Crear(AnuncioModelo modelo)
        {
            var consulta = "INSERT INTO Anuncio VALUES(@IdPrograma,@NifPatrocinador,@DuracionAnuncio,@PrecioPorSegundo)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.IdPrograma, modelo.NifPatrocinador,modelo.DuracionAnuncio,modelo.PrecioPorSegundo });
            }
        }

        public void Editar(AnuncioModelo modelo)
        {
            var consulta = "UPDATE Anuncio SET DuracionAnuncio = @DuracionAnuncio, PrecioPorSegundo = @PrecioPorSegundo WHERE IdAnuncio =@IdAnuncio";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.DuracionAnuncio, modelo.PrecioPorSegundo, modelo.IdAnuncio });
            }
        }

        public void Eliminar(int IdAnuncio)
        {
            var consulta = "DELETE FROM Anuncio WHERE IdAnuncio = @IdAnuncio";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { IdAnuncio});
            }
        }
    }
}