using BaseDeDatos.Repositorios;
using BaseDeDatos.Servicios;
using BaseDeDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BaseDeDatos.Vistas.MediosComunicacion
{
    public partial class Crear : System.Web.UI.Page
    {
        PersonasServicio personaServicio = new PersonasServicio();
        ProgramasServicio programaServicio = new ProgramasServicio();

        MediosComunicacionServicio mcservicio = new MediosComunicacionServicio();

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

            if (persona.Value == "persona")
            {
                txtNifRep.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreRep.Text = Server.HtmlDecode(row.Cells[1].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (mcservicio.ExisteMedio(txtNif.Text))
                {
                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ya existe un medio de comunicación con el nif especificado";
                    Page.Validators.Add(err);
                    return;
                }
                else
                {

                    var medModelo = new MediosComunicacionModelo();

                    medModelo.Nif = txtNif.Text;
                    medModelo.Nombre = txtNombre.Text;
                    medModelo.Direccion = txtDireccion.Text;
                    medModelo.NifPersona = txtNifRep.Text;

                    mcservicio.Crear(medModelo);
                    Response.Redirect("Index.aspx", true);
                }

            }
            catch (Exception ex)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al insertar el registro" + ex.ToString();
                Page.Validators.Add(err);

            }

        }
    }
}