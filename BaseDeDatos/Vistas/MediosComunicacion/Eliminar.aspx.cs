using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;

namespace BaseDeDatos.Vistas.MediosComunicacion
{
    public partial class Eliminar : System.Web.UI.Page
    {
        MediosComunicacionServicio mdComunicacion = new MediosComunicacionServicio();
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nif = Request.QueryString["NIF"];
                var medioComunicacion = mdComunicacion.ObtenerUnica(nif);
                var persona = personaServicio.ObtenerUnica(medioComunicacion.NifPersona);
                lblNif.Text = nif;
                lblNombre.Text = medioComunicacion.Nombre.ToString();
                lblDireccion.Text = medioComunicacion.Direccion;
                lblDirector.Text = persona.Nombres + " " + persona.Apellidos;
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
                mdComunicacion.Eliminar(lblNif.Text);
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