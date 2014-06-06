using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;

namespace BaseDeDatos.Vistas.Provincias
{
    public partial class Crear : System.Web.UI.Page
    {
        ProvinciaServicio provinciaServicio = new ProvinciaServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
             var provinciaModelo = new ProvinciaModelo();
            provinciaModelo.Descripcion = txtDescripcion.Text;
            provinciaModelo.Ubicacion = txtUbicacion.Text;
            provinciaServicio.Crear(provinciaModelo);
            Response.Redirect("Index.aspx", true);
            }
            catch (Exception)
            {

               CustomValidator err = new CustomValidator();
               err.IsValid = false;
               err.ErrorMessage = "Ocurrio un error al insertar el registro";
               Page.Validators.Add(err);
               
            }
          


        }
    }
}