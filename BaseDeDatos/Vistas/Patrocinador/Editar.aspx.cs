using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Patrocinador
{
    public partial class Editar : System.Web.UI.Page
    {
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nifPatrocinador = Request.QueryString["nif"];
                var patrocinador = patrocinadorServicio.ObtenerUnica(nifPatrocinador);
                txtNif.Text = nifPatrocinador;
                txtNombre.Text = patrocinador.Nombre;
                txtDireccion.Text = patrocinador.Direccion;
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
                var patrocinadorModelo = new PatrocinadoresModelo();
                patrocinadorModelo.NifPatrocinador = txtNif.Text;
                patrocinadorModelo.Nombre = txtNombre.Text;
                patrocinadorModelo.Direccion = txtDireccion.Text;
                patrocinadorServicio.Editar(patrocinadorModelo);
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