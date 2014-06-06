using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.BandaHertziana
{
    public partial class Editar : System.Web.UI.Page
    {
        BandaHertzianaServicio bandaServicio = new BandaHertzianaServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idBanda = Request.QueryString["IdBanda"];
                var banda = bandaServicio.ObtenerUnica(int.Parse(idBanda));
                txtDescripcion.Text = banda.Descripcion;
                txtDel.Text = banda.Del.ToString();
                txtAl.Text = banda.Al.ToString();
                hdfIdBanda.Value = idBanda;
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
                var bandaModelo = new BandaHertzianaModelo();
                bandaModelo.IdBandaHertziana = int.Parse(hdfIdBanda.Value);
                bandaModelo.Descripcion = txtDescripcion.Text;
                bandaModelo.Del = decimal.Parse(txtDel.Text);
                bandaModelo.Al = decimal.Parse(txtAl.Text);
                bandaServicio.Editar(bandaModelo);
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