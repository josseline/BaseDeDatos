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
    public class BandaHertzianaRepositorio
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<BandaHertzianaModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT * FROM BandaHertziana";

            if (sortBy == "IdBandaHertziana")
            {
                consulta = consulta + " ORDER BY IdBandaHertziana";
            }
            else if (sortBy == "IdBandaHertziana DESC")
            {
                consulta = consulta + " ORDER BY IdBandaHertziana DESC";
            }
            else if (sortBy == "Descripcion")
            {
                consulta = consulta + " ORDER BY Descripcion";
            }
            else if (sortBy == "Descripcion DESC")
            {
                consulta = consulta + " ORDER BY Descripcion DESC";
            }
         

            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<BandaHertzianaModelo>(consulta);
            }
        }

         public BandaHertzianaModelo ObtenerUnica(int idBanda)
        {
            var consulta = "SELECT TOP 1 * FROM BandaHertziana WHERE IdBandaHertziana = @IdBanda";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<BandaHertzianaModelo>(consulta, new { idBanda }).FirstOrDefault();
            }
        }
       public void Crear(BandaHertzianaModelo modelo)
       {
           var consulta = "INSERT INTO BandaHertziana VALUES(@Descripcion, @Del, @Al)";
           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Descripcion, modelo.Del, modelo.Al});
           }
       }

       public void Editar(BandaHertzianaModelo modelo)
       {
           var consulta = "UPDATE BandaHertziana SET Descripcion = @Descripcion, Del = @Del, Al=@Al WHERE IdBandaHertziana =@IdBandaHertziana";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Descripcion, modelo.Del, modelo.Al, modelo.IdBandaHertziana });
           }
       }

       public void Eliminar(int idBanda)
       {
           var consulta = "DELETE FROM BandaHertziana WHERE IdBandaHertziana = @IdBanda";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { idBanda });
           }
       }
       public IEnumerable<BandaHertzianaModelo> ObtenerPorBusqueda(string criterio)
       {

           var consulta = "SELECT * FROM BandaHertziana ";
           IEnumerable<BandaHertzianaModelo> listadoBanda;
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
                   listadoBanda = con.Query<BandaHertzianaModelo>(consulta, parametros);
               }
           }
           else
           {
               using (var con = new SqlConnection(connectionString))
               {
                   listadoBanda = con.Query<BandaHertzianaModelo>(consulta);
               }
           }

           var resultado = listadoBanda.ToList();
           return resultado;

       }

    }
}