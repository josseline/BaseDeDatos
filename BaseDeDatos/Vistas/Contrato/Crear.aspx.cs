using BaseDeDatos.Repositorios;
using BaseDeDatos.Servicios;
using BaseDeDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BaseDeDatos.Vistas.Contrato
{
    public partial class Crear : System.Web.UI.Page
    {
        ContratoServicio contratoServicio = new ContratoServicio();
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
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
                txtNifRep.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreRep.Text = Server.HtmlDecode(row.Cells[1].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusqueda.Text = "";

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {

                if (contratoServicio.ExisteContrato(txtContrado.Text))
                {
                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ya existe un contrato con el número especificado";
                    Page.Validators.Add(err);
                    return;
                }
                else
                {
                    var contratoModelo = new ContratoModelo();

                    contratoModelo.NoContrato = txtContrado.Text;
                    contratoModelo.Duracion = Convert.ToInt32(txtDuracion.Text);
                    contratoModelo.NifPatrocinador = txtNifRep.Text;

                    contratoServicio.Crear(contratoModelo);
                    Response.Redirect("Index.aspx", true);
                }

            }
            catch (Exception ex)
            {

                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al insertar el registro" + ex.ToString();
                Page.Validators.Add(err);

            }

        }
    }
}