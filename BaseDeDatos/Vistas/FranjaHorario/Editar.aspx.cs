using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.FranjaHorario
{
    public partial class Editar : System.Web.UI.Page
    {
        FranjaHorarioServicio franjaServicio = new FranjaHorarioServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idFranja = Request.QueryString["IdFranjaHorario"];
                var franja = franjaServicio.ObtenerUnica(int.Parse(idFranja));
                txtHoraInicio.Text = franja.HoraInicio;
                txtHoraFin.Text = franja.HoraFin;
                ddlDiaSemana.SelectedValue = franja.DiaSemana;
                hdfIdFranja.Value = idFranja;
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
                var franjaModelo = new FranjaHorarioModelo();
                franjaModelo.IdFranjaHorario = int.Parse(hdfIdFranja.Value);
                franjaModelo.HoraInicio = txtHoraInicio.Text;
                franjaModelo.HoraFin = txtHoraFin.Text;
                franjaModelo.DiaSemana = ddlDiaSemana.SelectedValue;
                franjaServicio.Editar(franjaModelo);
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