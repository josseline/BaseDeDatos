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
    public class EmisoraRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<EmisorasModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT EM.NIF, EM.NOMBRE, EM.DIRECCION, PRO.DESCRIPCION FROM EMISORAS EM INNER JOIN PROVINCIA PRO ON EM.IDPROVINCIA = PRO.IDPROVINCIA";

            if (sortBy == "Nombre")
            {
                consulta = consulta + " ORDER BY Nombre";
            }
            else if (sortBy == "Nombre DESC")
            {
                consulta = consulta + " ORDER BY Nombre DESC";
            }
            else if (sortBy == "NIF")
            {
                consulta = consulta + " ORDER BY NIF";
            }
            else if (sortBy == "NIF DESC")
            {
                consulta = consulta + " ORDER BY NifPatrocinador NIF";
            }


            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<EmisorasModelo>(consulta);
            }
        }

        public EmisorasModelo ObtenerUnica(string NIF)
        {
            var consulta = "SELECT TOP 1 * FROM EMISORAS WHERE NIF = @NIF";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<EmisorasModelo>(consulta, new { NIF }).FirstOrDefault();
            }
        }
        public void Crear(EmisorasModelo modelo)
        {
            var consulta = "INSERT INTO EMISORAS VALUES(@NIF,@Nombre,@Direccion,@IdBandaHertziana,@IdProvincia,@IdPrograma)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nif, modelo.Nombre, modelo.Direccion, modelo.IdBandaHertziana, modelo.IdProvincia,modelo.IdPrograma });
            }
        }

        public void Editar(EmisorasModelo modelo)
        {
            var consulta = "UPDATE EMISORAS SET Nombre = @Nombre, Direccion = @Direccion WHERE nif =@NIF";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombre, modelo.Direccion, modelo.Nif });
            }
        }

        public void Eliminar(int NIF)
        {
            var consulta = "DELETE FROM EMISORAS WHERE NIF = @NIF";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { NIF });
            }
        }
        public IEnumerable<EmisorasModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM EMISORAS ";
            IEnumerable<EmisorasModelo> listadoEmisoras;
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
                    listadoEmisoras = con.Query<EmisorasModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listadoEmisoras = con.Query<EmisorasModelo>(consulta);
                }
            }

            var resultado = listadoEmisoras.ToList();
            return resultado;

        }

        public bool ExisteEmisora(string nifEmisora)
        {
            var consulta = "SELECT * FROM Emisoras WHERE NIF = @nifEmisora";


            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<EmisorasModelo>(consulta, new { nifEmisora = nifEmisora });
                
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