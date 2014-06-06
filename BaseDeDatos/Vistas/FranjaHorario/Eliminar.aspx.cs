using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.FranjaHorario
{
    public partial class Eliminar : System.Web.UI.Page
    {
        FranjaHorarioServicio franjaServicio = new FranjaHorarioServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string idFranja = Request.QueryString["IdFranjaHorario"];
                var franja = franjaServicio.ObtenerUnica(int.Parse(idFranja));
                lblHoraInicio.Text = franja.HoraInicio;
                lblHoraFin.Text = franja.HoraFin;
                lblDiaSemana.Text = franja.DiaSemana;
                lblId.Text = idFranja;
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
                franjaServicio.Eliminar(id);
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