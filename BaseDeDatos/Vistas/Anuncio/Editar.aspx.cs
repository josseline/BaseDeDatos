using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BaseDeDatos.Vistas.Anuncio
{
    public partial class Editar : System.Web.UI.Page
    {
        AnuncioServicio anuncioServicio = new AnuncioServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idanuncio = Request.QueryString["IdAnuncio"];
                var cadena = anuncioServicio.ObtenerUnica(int.Parse(idanuncio));
                txtIdPrograma.Text = cadena.IdPrograma.ToString();
                txtNombre.Text = cadena.NombrePrograma;
                txtNifRep.Text = cadena.NifPatrocinador;
                txtNombreRep.Text = cadena.NombrePatrocinador;
                txtDuracionAnuncio.Text = cadena.DuracionAnuncio.ToString();
                txtPrecioPorSegundo.Text = cadena.PrecioPorSegundo.ToString();

                hdfIdCadena.Value = idanuncio;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var anuncioModelo = new AnuncioModelo();
                anuncioModelo.IdAnuncio = int.Parse(hdfIdCadena.Value);
                anuncioModelo.DuracionAnuncio = int.Parse(txtDuracionAnuncio.Text);
                anuncioModelo.PrecioPorSegundo = Convert.ToDecimal(txtPrecioPorSegundo.Text);
                anuncioServicio.Editar(anuncioModelo);
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index");
        }
    }
}