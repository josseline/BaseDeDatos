using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Provincias
{
    public partial class Eliminar : System.Web.UI.Page
    { 
        ProvinciaServicio provinciaServicio = new ProvinciaServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!Page.IsPostBack)
            {
                string idProvincia = Request.QueryString["IdProvincia"];
                var provincia = provinciaServicio.ObtenerUnica(int.Parse(idProvincia));
                lblDescripcion.Text = provincia.Descripcion;
                lblUbicacion.Text = provincia.Ubicacion;
                lblId.Text = idProvincia;
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
                provinciaServicio.Eliminar(id);
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