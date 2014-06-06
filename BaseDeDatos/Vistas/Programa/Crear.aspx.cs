using BaseDeDatos.Models;
using BaseDeDatos.Repositorios;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Programa
{
    public partial class Crear : System.Web.UI.Page
    {
        ProgramasServicio programaServicio = new ProgramasServicio();
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var personas = personaServicio.ObtenerPorBusqueda(txtBusqueda.Text);
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
         }

        protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
              GridViewRow row = gvPersonas.SelectedRow;

            if(persona.Value == "persona")
            {
                txtNifRep.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreRep.Text = Server.HtmlDecode(row.Cells[1].Text) + " " +  Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";
       
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
              
                    var programaModelo = new ProgramasModelo();
                    programaModelo.NifPersona = txtNifRep.Text;
                    programaModelo.Nombre = txtNombrePrograma.Text;
                 
                    programaServicio.Crear(programaModelo);
                    Response.Redirect("Index.aspx", true);
                
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