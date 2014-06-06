using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace BaseDeDatos.Repositorios
{
    public class ProvinciasRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<ProvinciaModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT * FROM Provincia";

             if(sortBy == "IdProvincia")
            {
                 consulta = consulta + " ORDER BY IdProvincia";
            }
             else if (sortBy == "IdProvincia DESC")
             {
                 consulta = consulta + " ORDER BY IdProvincia DESC";
             }
             else if (sortBy == "Descripcion")
             {
                 consulta = consulta + " ORDER BY Descripcion";
             }
             else if (sortBy == "Descripcion DESC")
             {
                 consulta = consulta + " ORDER BY Descripcion DESC";
             }
             else if (sortBy == "Ubicacion")
             {
                 consulta = consulta + " ORDER BY Ubicacion";
             }
             else if (sortBy == "Ubicacion DESC")
             {
                 consulta = consulta + " ORDER BY Ubicacion DESC";
             }
        
            

            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProvinciaModelo>(consulta);
            }
        }

        public ProvinciaModelo ObtenerUnica(int idProvincia)
        {
            var consulta = "SELECT TOP 1 * FROM Provincia WHERE IdProvincia = @IdProvincia";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<ProvinciaModelo>(consulta, new { idProvincia }).FirstOrDefault();
            }
        }
       public void Crear(ProvinciaModelo modelo)
       {
           var consulta = "INSERT INTO Provincia VALUES(@Descripcion, @Ubicacion)";
           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Descripcion, modelo.Ubicacion});
           }
       }

       public void Editar(ProvinciaModelo modelo)
       {
           var consulta = "UPDATE Provincia SET Descripcion = @Descripcion, Ubicacion = @Ubicacion WHERE IdProvincia =@IdProvincia";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Descripcion, modelo.Ubicacion, modelo.IdProvincia });
           }
       }

       public void Eliminar(int idProvincia)
       {
           var consulta = "DELETE FROM Provincia WHERE IdProvincia = @IdProvincia";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { idProvincia });
           }
       }
       public IEnumerable<ProvinciaModelo> ObtenerPorBusqueda(string criterio)
       {

           var consulta = "SELECT * FROM PROVINCIA ";
           IEnumerable<ProvinciaModelo> listadoBanda;
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
                       var where = string.Format("Descripcion LIKE {0}", nombre);
                       listaWhere.Add(where);
                       parametros.Add(nombre, "%" + palabra + "%");
                   }

                   i++;
               }
               var nuevoWhere = String.Join("AND", listaWhere);
               consulta = consulta + " where " + nuevoWhere;
               using (var con = new SqlConnection(connectionString))
               {
                   listadoBanda = con.Query<ProvinciaModelo>(consulta, parametros);
               }
           }
           else
           {
               using (var con = new SqlConnection(connectionString))
               {
                   listadoBanda = con.Query<ProvinciaModelo>(consulta);
               }
           }

           var resultado = listadoBanda.ToList();
           return resultado;

       }


    }
}