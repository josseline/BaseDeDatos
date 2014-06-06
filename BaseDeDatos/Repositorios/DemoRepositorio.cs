using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace BaseDeDatos.Repositorios
{

    public class DemoModelo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class DemoRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<DemoModelo> ObtenerTodos()
        {

            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<DemoModelo>("SELECT Codigo Id, Descripcion Nombre FROM Demos Where Codigo = @Id", new { Id = 1 });
            }

        }
        

    }
}