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
    public class CadenaRadioRepositorio
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<CadenaRadioModelo> ObtenerTodas(string sortBy)
        {
            var consulta = "SELECT * FROM CadenaRadio";

            if (sortBy == "IdCadena")
            {
                consulta = consulta + " ORDER BY IdCadena";
            }
            else if (sortBy == "IdCadena DESC")
            {
                consulta = consulta + " ORDER BY IdCadena DESC";
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
                return con.Query<CadenaRadioModelo>(consulta);
            }
        }

         public CadenaRadioModelo ObtenerUnica(int idCadena)
        {
            var consulta = "SELECT TOP 1 * FROM CadenaRadio WHERE IdCadena = @IdCadena";
            using (var con = new SqlConnection(connectionString))
            {
                return con.Query<CadenaRadioModelo>(consulta, new { idCadena }).FirstOrDefault();
            }
        }
       public void Crear(CadenaRadioModelo modelo)
       {
           var consulta = "INSERT INTO CadenaRadio VALUES(@Nombre)";
           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Nombre});
           }
       }

       public void Editar(CadenaRadioModelo modelo)
       {
           var consulta = "UPDATE CadenaRadio SET Nombre = @Nombre WHERE IdCadena =@IdCadena";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { modelo.Nombre, modelo.IdCadena });
           }
       }

       public void Eliminar(int idCadena)
       {
           var consulta = "DELETE FROM CadenaRadio WHERE IdCadena = @IdCadena";

           using (var con = new SqlConnection(connectionString))
           {
               con.Execute(consulta, new { idCadena });
           }
       }
       public IEnumerable<CadenaRadioModelo> ObtenerPorBusqueda(string criterio)
       {

           var consulta = "SELECT * FROM CadenaRadio ";
           IEnumerable<CadenaRadioModelo> listaCadenas;
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
                       var where = string.Format("NOMBRE LIKE {0}", nombre);
                       listaWhere.Add(where);
                       parametros.Add(nombre, "%" + palabra + "%");
                   }

                   i++;
               }
               var nuevoWhere = String.Join("AND", listaWhere);
               consulta = consulta + " where " + nuevoWhere;
               using (var con = new SqlConnection(connectionString))
               {
                   listaCadenas = con.Query<CadenaRadioModelo>(consulta, parametros);
               }
           }
           else
           {
               using (var con = new SqlConnection(connectionString))
               {
                   listaCadenas = con.Query<CadenaRadioModelo>(consulta);
               }
           }

           var resultado = listaCadenas.ToList();
           return resultado;

       }

    }
    }
