using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Contrato
{
    public partial class Editar : System.Web.UI.Page
    {
        ContratoServicio contratoServicio = new ContratoServicio();
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string noContrato = Request.QueryString["NoContrato"];
                var contrato = contratoServicio.ObtenerUnica(noContrato);
                var patrocinador = patrocinadorServicio.ObtenerUnica(contrato.NifPatrocinador);
                txtContrado.Text = noContrato;
                txtNifPatrocinador.Text = patrocinador.NifPatrocinador;
                txtNombrePatrocinador.Text = patrocinador.Nombre;
                txtDuracion.Text = contrato.Duracion.ToString();
            }
        }


        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var personas = patrocinadorServicio.ObtenerPorBusqueda(txtBusqueda.Text);
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }

        protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPersonas.SelectedRow;

            if (persona.Value == "persona")
            {
                txtNifPatrocinador.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombrePatrocinador.Text = Server.HtmlDecode(row.Cells[1].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
try
            {
                var contratoModelo = new ContratoModelo();
                contratoModelo.NoContrato= txtContrado.Text;
                contratoModelo.Duracion = int.Parse(txtDuracion.Text);
                contratoModelo.NifPatrocinador = txtNifPatrocinador.Text;
            
                contratoServicio.Editar(contratoModelo);
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