using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.ProgramaFranja
{
    public partial class Editar : System.Web.UI.Page
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

                txtIdPrograma.Text = pf.IdPrograma.ToString();
                txtNombrePrograma.Text = programa.Nombre;
                txtIdFranja.Text = franjaH.IdFranjaHorario.ToString();
                txtDescripcionFranja.Text = franjaH.HoraInicio + " - " + franjaH.HoraFin + " - " + franjaH.DiaSemana;
               
                hdfProgramaFranjaId.Value = id;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                var pfModelo = new ProgramaFranjaModelo();
                pfModelo.IdPrograma = int.Parse(txtIdPrograma.Text);
                pfModelo.IdFranjaHorario = int.Parse(txtIdFranja.Text);
             
                pfServicio.Editar(pfModelo);
                Response.Redirect("Index.aspx", true);
            }
            catch (Exception ex)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al editar el registro" + ' ' + ex.ToString();
                Page.Validators.Add(err);

            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var personas = franjahServicio.ObtenerPorBusqueda(txtBusqueda.Text);
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }
        protected void txtBusquedaPrograma_TextChanged(object sender, EventArgs e)
        {

            var programa = programaServicio.ObtenerPorBusqueda(txtBusquedaPrograma.Text);
            gvPrograma.DataSource = programa;
            gvPrograma.DataBind();
        }

        protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPersonas.SelectedRow;

            if (persona.Value == "persona")
            {
                txtIdFranja.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtDescripcionFranja.Text = Server.HtmlDecode(row.Cells[1].Text) + " - " + Server.HtmlDecode(row.Cells[2].Text) + " - " + Server.HtmlDecode(row.Cells[3].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";

        }

        protected void gvPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPrograma.SelectedRow;

            if (programa.Value == "programa")
            {
                txtIdPrograma.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombrePrograma.Text = Server.HtmlDecode(row.Cells[1].Text) + " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";

        }
    }
}