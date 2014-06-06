using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Provincias
{
    public partial class Editar : System.Web.UI.Page
    {
        ProvinciaServicio provinciaServicio = new ProvinciaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idProvincia = Request.QueryString["IdProvincia"];
                var provincia = provinciaServicio.ObtenerUnica(int.Parse(idProvincia));
                txtDescripcion.Text = provincia.Descripcion;
                txtUbicacion.Text = provincia.Ubicacion;
                hdfIdProvincia.Value = idProvincia;
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
               var provinciaModelo = new ProvinciaModelo();
               provinciaModelo.IdProvincia = int.Parse(hdfIdProvincia.Value);
               provinciaModelo.Descripcion = txtDescripcion.Text;
               provinciaModelo.Ubicacion = txtUbicacion.Text;
               provinciaServicio.Editar(provinciaModelo);
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