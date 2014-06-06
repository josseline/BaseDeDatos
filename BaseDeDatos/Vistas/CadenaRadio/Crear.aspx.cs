using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.CadenaRadio
{
    public partial class Crear : System.Web.UI.Page
    {
        CadenaRadioServicio cadenaServicio = new CadenaRadioServicio();
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
                var cadenaModelo = new CadenaRadioModelo();
                cadenaModelo.Nombre = txtNombre.Text;
                cadenaServicio.Crear(cadenaModelo);
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