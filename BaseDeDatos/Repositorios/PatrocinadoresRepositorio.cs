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
    public class PatrocinadoresRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<PatrocinadoresModelo> ObtenerTodos(string sortBy)
        {
            var consulta = "SELECT * FROM Patrocinadores";

            if (sortBy == "NIFPatrocinador")
            {
                consulta = consulta + " ORDER BY NIFPatrocinador";
            }
            else if (sortBy == "NIFPatrocinador DESC")
            {
                consulta = consulta + " ORDER BY NIFPatrocinador DESC";
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
                return con.Query<PatrocinadoresModelo>(consulta);
            }
        }

        public PatrocinadoresModelo ObtenerUnico(string nifPatrocinador)
        {
            var consulta = "SELECT TOP 1 * FROM Patrocinadores WHERE NIFPatrocinador = @nifPatrocinador";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<PatrocinadoresModelo>(consulta, new { nifPatrocinador }).FirstOrDefault();
            }
        }
        public void Crear(PatrocinadoresModelo modelo)
        {
            var consulta = "INSERT INTO Patrocinadores VALUES(@NifPatrocinador, @Nombre, @Direccion)";
            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.NifPatrocinador, modelo.Nombre, modelo.Direccion });
            }
        }

        public void Editar(PatrocinadoresModelo modelo)
        {
            var consulta = "UPDATE Patrocinadores SET Nombre = @Nombre, Direccion = @Direccion WHERE NIFPatrocinador =@NifPatrocinador";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { modelo.Nombre, modelo.Direccion, modelo.NifPatrocinador });
            }
        }

        public void Eliminar(string nifPatrocinador)
        {
            var consulta = "DELETE FROM Patrocinadores WHERE NIFPatrocinador = @nifPatrocinador";

            using (var con = new SqlConnection(connectionString))
            {
                con.Execute(consulta, new { nifPatrocinador });
            }
        }

        public bool ExisteNifPatrocinador(string nifPatrocinador)
        {
            var consulta = "SELECT * FROM Patrocinadores WHERE NIFPatrocinador = @nifPatrocinador";
           
          
            using (var con = new SqlConnection(connectionString))
            {
                var resultado = con.Query<PatrocinadoresModelo>(consulta, new { nifPatrocinador });
               
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

        public IEnumerable<PatrocinadoresModelo> ObtenerPorBusqueda(string criterio)
        {

            var consulta = "SELECT * FROM Patrocinadores ";
            IEnumerable<PatrocinadoresModelo> listadoProgramas;
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
                    listadoProgramas = con.Query<PatrocinadoresModelo>(consulta, parametros);
                }
            }
            else
            {
                using (var con = new SqlConnection(connectionString))
                {
                    listadoProgramas = con.Query<PatrocinadoresModelo>(consulta);
                }
            }

            var resultado = listadoProgramas.ToList();
            return resultado;

        }

    }
}