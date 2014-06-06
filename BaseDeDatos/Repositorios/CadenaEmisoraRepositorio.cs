using BaseDeDatos.Models;
using System;
using System.Collections.Generic;
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
    public class CadenaEmisoraRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<CadenaEmisoraModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT ce.IdCadena, ce.NifEmisora, cad.Nombre Cadena, em.Nombre Emisora, CONCAT(p.Nombres, ' ', p.Apellidos) Director, ce.EsCentral FROM CadenaEmisora ce INNER JOIN CadenaRadio cad ON ce.IdCadena = cad.IdCadena INNER JOIN Emisoras em ON ce.NifEmisora = em.NIF INNER JOIN Personas p ON ce.NIFPERSONA = p.NIFPERSONA";

            if (sortBy == "Cadena")
            {
                consulta = consulta + " ORDER BY cad.Nombre";
            }
            else if (sortBy == "Cadena DESC")
            {
                consulta = consulta + " ORDER BY cad.Nombre DESC";
            }
            else if (sortBy == "Emisora")
            {
                consulta = consulta + " ORDER BY em.Nombre";
            }
            else if (sortBy == "Emisora DESC")
            {
                consulta = consulta + " ORDER BY em.Nombre DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<CadenaEmisoraModelo>(consulta);
            }
        }

        public CadenaEmisoraModelo ObtenerUnica(int idCadena, string nifEmisora)
        {
            var consulta = "SELECT TOP 1 * FROM CadenaEmisora WHERE IdCadena = @IdCadena and NifEmisora = @NifEmisora";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<CadenaEmisoraModelo>(consulta, new { IdCadena = idCadena, NifEmisora = nifEmisora }).FirstOrDefault();
            }
        }
        public void Crear(CadenaEmisoraModelo modelo)
        {
            var consulta = "INSERT INTO CadenaEmisora VALUES(@IdCadena, @NifEmisora, @EsCentral, @NIFPERSONA)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.IdCadena, modelo.NifEmisora, modelo.EsCentral, modelo.NifPersona });
            }
        }

        public void Editar(CadenaEmisoraModelo modelo)
        {
            var consulta = "UPDATE CadenaEmisora SET IdCadena = @IdCadena, NifEmisora = @NifEmisora, EsCentral =@EsCentral, NIFPERSONA = @NifPersona WHERE IdCadena =@IdCadena AND NifEmisora = @NifEmisora";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.IdCadena, modelo.NifEmisora, modelo.EsCentral, modelo.NifPersona });
            }
        }

        public void Eliminar(int IdCadena, string NifEmisora)
        {
            var consulta = "DELETE FROM CadenaEmisora WHERE IdCadena = @IdCadena AND NifEmisora = @NifEmisora";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { IdCadena, NifEmisora });
            }
        }


        public bool ExisteCadenaEmisora(int idCadena, string nifEmisora)
        {
            var consulta = "SELECT * FROM CadenaEmisora WHERE IDcadena = @idCadena and NifEmisora = @nifEmisora";


            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<CadenaEmisoraModelo>(consulta, new { idCadena, nifEmisora });
                var cadenaEmisora = resultado.FirstOrDefault();
                if (resultado.Count() == 0 )
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