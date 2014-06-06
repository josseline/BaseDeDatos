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
    public partial class Editar : System.Web.UI.Page
    {
        CadenaRadioServicio cadenaServicio = new CadenaRadioServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idCadena = Request.QueryString["IdCadena"];
                var cadena = cadenaServicio.ObtenerUnica(int.Parse(idCadena));
                txtNombre.Text = cadena.Nombre;
                hdfIdCadena.Value = idCadena;
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cadenaModelo = new CadenaRadioModelo();
                cadenaModelo.IdCadena = int.Parse(hdfIdCadena.Value);
                cadenaModelo.Nombre = txtNombre.Text;
                cadenaServicio.Editar(cadenaModelo);
                Response.Redirect("Index.aspx", true);
            }
            catch (Exception)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al editar el registro";
                Page.Validators.Add(err);

            }
        }
    }
}