using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;


namespace BaseDeDatos.Vistas.Emisora
{
    public partial class Eliminar : System.Web.UI.Page
    {
        EmisoraServicio emisoraServicio = new EmisoraServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nif = Request.QueryString["NIF"];
                var cadena = emisoraServicio.ObtenerUnica(nif);
                lblNombre.Text = cadena.Nombre.ToString();
                lblId.Text = cadena.Nif.ToString();
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
                emisoraServicio.Eliminar(id);
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