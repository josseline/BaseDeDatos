using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.CadenaRadio
{
    public partial class Eliminar : System.Web.UI.Page
    {
        CadenaRadioServicio cadenaServicio = new CadenaRadioServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idCadena = Request.QueryString["IdCadena"];
                var cadena = cadenaServicio.ObtenerUnica(int.Parse(idCadena));
                lblNombre.Text = cadena.Nombre;
                lblId.Text = idCadena;
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
                var id = int.Parse(lblId.Text);
                cadenaServicio.Eliminar(id);
                Response.Redirect("Index.aspx", true);
            }
            catch (Exception)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al eliminar el registro";
                Page.Validators.Add(err);
            }
        }
    }
}