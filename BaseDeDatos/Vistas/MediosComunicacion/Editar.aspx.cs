using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.MediosComunicacion
{
    public partial class Editar : System.Web.UI.Page
    {
        MediosComunicacionServicio mcComunicacion = new MediosComunicacionServicio();
        PersonasServicio personaServicio = new PersonasServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nif = Request.QueryString["Nif"];
                var mComunicacion = mcComunicacion.ObtenerUnica(nif);
                var persona = personaServicio.ObtenerUnica(mComunicacion.NifPersona);
                txtNombre.Text = mComunicacion.Nombre.ToString();
                txtDireccion.Text = mComunicacion.Direccion.ToString();
                txtNif.Text = nif;
                txtNifRep.Text = mComunicacion.NifPersona;
                txtNombreRep.Text = persona.Nombres + " " + persona.Apellidos;
               
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index");
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

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
            try
            {
                var mcModelo = new MediosComunicacionModelo();
                mcModelo.Nombre = txtNombre.Text;
                mcModelo.Direccion = txtDireccion.Text;
                mcModelo.Nif = txtNif.Text;
                mcModelo.NifPersona = txtNifRep.Text;
                mcComunicacion.Editar(mcModelo);
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