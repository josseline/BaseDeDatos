using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;

namespace BaseDeDatos.Vistas.Contrato
{
    public partial class Eliminar : System.Web.UI.Page
    {
        ContratoServicio contratoServicio = new ContratoServicio();
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string Nocontrato = Request.QueryString["NoContrato"];
                var contrato = contratoServicio.ObtenerUnica(Nocontrato);
                var patrocinador = patrocinadorServicio.ObtenerUnica(contrato.NifPatrocinador);
                //lblNombre.Text = cadena.Duracion.ToString();
                lblContrato.Text = contrato.NoContrato;
                lblDuracion.Text = contrato.Duracion.ToString();
                lblPatrocinador.Text = patrocinador.Nombre;

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
                contratoServicio.Eliminar(lblContrato.Text);
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