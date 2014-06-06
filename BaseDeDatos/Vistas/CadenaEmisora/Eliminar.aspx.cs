using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDeDatos.Servicios;

namespace BaseDeDatos.Vistas.CadenaEmisora
{
    public partial class Eliminar : System.Web.UI.Page
    {
        CadenaEmisoraServicio cadenaEmisoraServicio = new CadenaEmisoraServicio();
        PersonasServicio personaServicio = new PersonasServicio();
        EmisoraServicio emisoraServicio = new EmisoraServicio();
        CadenaRadioServicio cadenaRadioServicio = new CadenaRadioServicio();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idCadena = Request.QueryString["IdCadena"];
                string nifEmisora = Request.QueryString["NifEmisora"];
                var cadenaEmisora = cadenaEmisoraServicio.ObtenerUnica(int.Parse(idCadena), nifEmisora);
                var director = personaServicio.ObtenerUnica(cadenaEmisora.NifPersona);
                var cadena = cadenaRadioServicio.ObtenerUnica(int.Parse(idCadena));
                var emisora = emisoraServicio.ObtenerUnica(nifEmisora);

                lblCadenaId.Text = idCadena;
                lblNombreCadena.Text = cadena.Nombre;
                lblNifEmisora.Text = nifEmisora;
                lblNombreEmisora.Text = emisora.Nombre;
                lblNifRepresentante.Text = director.NifPersona;
                lblNombreRepresentante.Text = director.Nombres + director.Apellidos;
                lblEsCentral.Text = cadenaEmisora.EsCentral == true ? "1" : "0";
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
                cadenaEmisoraServicio.Eliminar(int.Parse(lblCadenaId.Text), lblNifEmisora.Text);
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