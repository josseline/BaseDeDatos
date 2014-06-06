using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Programa
{
    public partial class Eliminar : System.Web.UI.Page
    {
        PersonasServicio personaServicio = new PersonasServicio();
        ProgramasServicio programaServicio = new ProgramasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];
                var programa = programaServicio.ObtenerUnica(int.Parse(id));
                var persona = personaServicio.ObtenerUnica(programa.NifPersona);
                lblId.Text = id;
                lblNombre.Text = programa.Nombre;
                lblNifPersona.Text = persona.NifPersona;
                lblNombrePersona.Text = persona.Nombres + " " + persona.Apellidos;

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
                var id = lblId.Text;
                programaServicio.Eliminar(int.Parse(id));
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