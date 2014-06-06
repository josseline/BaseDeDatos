using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Patrocinador
{
    public partial class Eliminar : System.Web.UI.Page
    {
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nifPatrocinador = Request.QueryString["nif"];
                var patrocinador = patrocinadorServicio.ObtenerUnica(nifPatrocinador);
                lblNif.Text = nifPatrocinador;
                lblNombre.Text = patrocinador.Nombre;
                lblDireccion.Text = patrocinador.Direccion;
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
                var nif = lblNif.Text;
                patrocinadorServicio.Eliminar(nif);
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