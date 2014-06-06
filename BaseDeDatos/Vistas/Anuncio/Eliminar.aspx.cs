using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;

namespace BaseDeDatos.Vistas.Anuncio
{
    public partial class Eliminar : System.Web.UI.Page
    {
        AnuncioServicio anuncioServicio = new AnuncioServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idAnuncio = Request.QueryString["IdAnuncio"];
                var cadena = anuncioServicio.ObtenerUnica(int.Parse(idAnuncio));
                lblNombre.Text = cadena.IdPrograma.ToString() + " " + cadena.NifPatrocinador.ToString() ;
                lblId.Text = cadena.IdAnuncio.ToString();
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
                anuncioServicio.Eliminar(id);
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