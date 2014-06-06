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
    public partial class Crear : System.Web.UI.Page
    {
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (personaServicio.ExisteNifPersona(txtNif.Text))
                {
                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ya existe una persona con el nif especificado";
                    Page.Validators.Add(err);
                    return;
                }
                else
                {
                    var personaModelo = new PersonaModelo();
                    personaModelo.NifPersona = txtNif.Text;
                    personaModelo.Nombres = txtNombre.Text;
                    personaModelo.Apellidos = txtApellidos.Text;
                    personaModelo.Direccion = txtDireccion.Text;
                    personaServicio.Crear(personaModelo);
                    Response.Redirect("Index.aspx", true);
                }
            }
            catch (Exception)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al insertar el registro";
                Page.Validators.Add(err);

            }
        }
    }
}