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
    public class MediosComunicacionRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<MediosComunicacionModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT mc.Nif, mc.Nombre, mc.Direccion, CONCAT(p.Nombres, ' ', p.Apellidos) NombrePersona FROM MediosComunicacion mc INNER JOIN Personas p ON mc.NIFPERSONA = p.NIFPERSONA";

            if (sortBy == "NIF")
            {
                consulta = consulta + " ORDER BY NIF";
            }
            else if (sortBy == "NIF DESC")
            {
                consulta = consulta + " ORDER BY NIF DESC";
            }
            else if (sortBy == "Nombre")
            {
                consulta = consulta + " ORDER BY Nombre";
            }
            else if (sortBy == "Nombre DESC")
            {
                consulta = consulta + " ORDER BY Nombre DESC";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<MediosComunicacionModelo>(consulta);
            }
        }

        public MediosComunicacionModelo ObtenerUnica(string NIF)
        {
            var consulta = "SELECT TOP 1 * FROM MediosComunicacion WHERE NIF = @NIF";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<MediosComunicacionModelo>(consulta, new { NIF }).FirstOrDefault();
            }
        }
        public void Crear(MediosComunicacionModelo modelo)
        {
            var consulta = "INSERT INTO MediosComunicacion VALUES(@NIF,@Nombre,@Direccion,@NifPersona)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nif, modelo.Nombre, modelo.Direccion, modelo.NifPersona });
            }
        }

        public void Editar(MediosComunicacionModelo modelo)
        {
            var consulta = "UPDATE MediosComunicacion SET Nombre = @Nombre, Direccion = @Direccion, NIFPERSONA = @NifPersona WHERE NIF =@NIF";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombre, modelo.Direccion, modelo.NifPersona, modelo.Nif });
            }
        }

        public void Eliminar(string Nif)
        {
            var consulta = "DELETE FROM MediosComunicacion WHERE NIF = @Nif";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { Nif });
            }
        }

        public bool ExisteMedio(string nifMedio)
        {
            var consulta = "SELECT * FROM MediosComunicacion WHERE Nif = @nifMedio";


            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<MediosComunicacionModelo>(consulta, new { nifMedio = nifMedio });

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