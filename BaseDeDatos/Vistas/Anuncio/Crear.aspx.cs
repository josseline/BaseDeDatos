    using BaseDeDatos.Repositorios;
    using BaseDeDatos.Servicios;
    using BaseDeDatos.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Anuncio
{
    public partial class Crear : System.Web.UI.Page
    {

            PersonasServicio personaServicio = new PersonasServicio();
            ProgramasServicio programaServicio = new ProgramasServicio();
            AnuncioServicio anuncioServicio = new AnuncioServicio();
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
                    txtNifRep.Text = Server.HtmlDecode(row.Cells[0].Text);
                    txtNombreRep.Text = Server.HtmlDecode(row.Cells[1].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
                }
                txtBusqueda.Text = "";

            }

            protected void gvPrograma_SelectedIndexChanged(object sender, EventArgs e)
            {
                GridViewRow row = gvPrograma.SelectedRow;

                if (programa.Value == "programa")
                {
                    txtIdPrograma.Text = Server.HtmlDecode(row.Cells[0].Text);
                    txtNombre.Text = Server.HtmlDecode(row.Cells[1].Text) + " " + Server.HtmlDecode(row.Cells[2].Text);
                }
                txtBusqueda.Text = "";

            }

            protected void btnCrear_Click(object sender, EventArgs e)
            {
                try
                {


                    var anuncioModelo = new AnuncioModelo();

                    anuncioModelo.IdPrograma = Convert.ToInt32(txtIdPrograma.Text);
                    anuncioModelo.NifPatrocinador = txtNifRep.Text;
                    anuncioModelo.DuracionAnuncio = Convert.ToInt32(txtDuracionAnuncio.Text);
                    anuncioModelo.PrecioPorSegundo = Convert.ToDecimal(txtPrecioPorSegundo.Text);

                    anuncioServicio.Crear(anuncioModelo);
                    Response.Redirect("Index.aspx", true);

                }
                catch (Exception ex)
                {

                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ocurrio un error al insertar el registro" + ex.ToString() ;
                    Page.Validators.Add(err);

                }

            }
    }
}