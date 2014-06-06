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
    public partial class Crear : System.Web.UI.Page
    {
        BandaHertzianaServicio bandaServicio = new BandaHertzianaServicio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

            Response.Redirect("Index.aspx", true);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                var bandaModelo = new BandaHertzianaModelo();
                bandaModelo.Descripcion = txtDescripcion.Text;
                bandaModelo.Del = decimal.Parse(txtDel.Text);
                bandaModelo.Al = decimal.Parse(txtAl.Text);
                bandaServicio.Crear(bandaModelo);
                Response.Redirect("Index.aspx", true);
            }
            catch (Exception)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al insertar el registro";
                Page.Validators.Add(err);

            }
        }
    }
}