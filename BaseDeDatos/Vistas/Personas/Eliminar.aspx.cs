using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Personas
{
    public partial class Elimina : System.Web.UI.Page
    {
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nifPersona = Request.QueryString["nif"];
                var persona = personaServicio.ObtenerUnica(nifPersona);
                lblNif.Text = nifPersona;
                lblNombres.Text = persona.Nombres;
                lblApellidos.Text = persona.Apellidos;
                lblDireccion.Text = persona.Direccion;
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
                personaServicio.Eliminar(nif);
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