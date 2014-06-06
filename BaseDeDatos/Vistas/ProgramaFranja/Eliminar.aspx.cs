using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;
namespace BaseDeDatos.Vistas.ProgramaFranja
{
    public partial class Eliminar : System.Web.UI.Page
    {
        PFServicio pfServicio = new PFServicio();
        FranjaHorarioServicio franjahServicio = new FranjaHorarioServicio();
        ProgramasServicio programaServicio = new ProgramasServicio();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["IdCorrelativo"];
                var pf = pfServicio.ObtenerUnica(int.Parse(id));
                var franjaH = franjahServicio.ObtenerUnica(pf.IdFranjaHorario);
                var programa = programaServicio.ObtenerUnica(pf.IdPrograma);

                lblId.Text = id;
                lblPrograma.Text = programa.Nombre;
                lblFranjaHorario.Text = franjaH.HoraInicio + " - " + franjaH.HoraFin + " - " + franjaH.DiaSemana;

              
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
                pfServicio.Eliminar(id);
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