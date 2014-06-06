using BaseDeDatos.Repositorios;
using BaseDeDatos.Servicios;
using BaseDeDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Emisora
{
    public partial class Crear : System.Web.UI.Page
    {

        BandaHertzianaServicio bandaServicio = new BandaHertzianaServicio();
        ProgramasServicio programaServicio = new ProgramasServicio();
        ProvinciaServicio provinciaServicio = new ProvinciaServicio();
        EmisoraServicio emisoraServicio = new EmisoraServicio();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx", true);
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var Banda = bandaServicio.ObtenerPorBusqueda(txtBusqueda.Text);
            gvBanda.DataSource = Banda;
            gvBanda.DataBind();
        }
        protected void txtBusquedaPrograma_TextChanged(object sender, EventArgs e)
        {

            var programa = programaServicio.ObtenerPorBusqueda(txtBusquedaPrograma.Text);
            gvPrograma.DataSource = programa;
            gvPrograma.DataBind();
        }
        protected void txtBusquedaprovincia_TextChanged(object sender, EventArgs e)
        {

            var provincia = provinciaServicio.ObtenerPorBusqueda(txtBusquedaProvincia.Text);
            gvProvincia.DataSource = provincia;
            gvProvincia.DataBind();
        }

        protected void gvBanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvBanda.SelectedRow;

            if (persona.Value == "persona")
            {
                txtBanda.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtDescripcion.Text = Server.HtmlDecode(row.Cells[1].Text);//+ " " + Server.HtmlDecode(row.Cells[2].Text);
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
        protected void gvProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvProvincia.SelectedRow;

            if (provincia.Value == "provincia")
            {
                txtIdProvincia.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtDescripcionProvincia.Text = Server.HtmlDecode(row.Cells[1].Text) + " " + Server.HtmlDecode(row.Cells[2].Text);
            }
            txtBusquedaProvincia.Text = "";

        }


        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {

                if (emisoraServicio.ExisteEmisora(txtNIF.Text))
                {
                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ya existe una emisora con el nif especificado";
                    Page.Validators.Add(err);
                    return;
                }
                else
                {
                    var emisoraModelo = new EmisorasModelo();

                    emisoraModelo.Nif = txtNIF.Text;
                    emisoraModelo.Nombre = txtNombreEmisora.Text;
                    emisoraModelo.Direccion = txtDireccion.Text;
                    emisoraModelo.IdBandaHertziana =int.Parse(txtBanda.Text);
                    emisoraModelo.IdProvincia = int.Parse(txtIdProvincia.Text);
                    emisoraModelo.IdPrograma = int.Parse(txtIdPrograma.Text);


                    emisoraServicio.Crear(emisoraModelo);
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