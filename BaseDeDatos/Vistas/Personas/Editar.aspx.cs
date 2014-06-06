using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Personas
{
    public partial class Editar : System.Web.UI.Page
    {
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nifPersona = Request.QueryString["nif"];
                var persona = personaServicio.ObtenerUnica(nifPersona);
                txtNif.Text = nifPersona;
                txtNombre.Text = persona.Nombres;
                txtApellidos.Text = persona.Apellidos;
                txtDireccion.Text = persona.Direccion;
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
                var personaModelo = new PersonaModelo();
                personaModelo.NifPersona = txtNif.Text;
                personaModelo.Nombres = txtNombre.Text;
                personaModelo.Apellidos = txtApellidos.Text;
                personaModelo.Direccion = txtDireccion.Text;
                personaServicio.Editar(personaModelo);
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