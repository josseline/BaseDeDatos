using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.BandaHertziana
{
    public partial class Eliminar : System.Web.UI.Page
    {
        BandaHertzianaServicio bandaServicio = new BandaHertzianaServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idBanda = Request.QueryString["IdBanda"];
                var banda = bandaServicio.ObtenerUnica(int.Parse(idBanda));
                lblDescripcion.Text = banda.Descripcion;
                lblDel.Text = banda.Del.ToString();
                lblAl.Text = banda.Al.ToString();
                lblId.Text = idBanda;
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
                bandaServicio.Eliminar(id);
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