using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Emisora
{
    public partial class Editar : System.Web.UI.Page
    {
        EmisoraServicio emisoraServicio = new EmisoraServicio();
        BandaHertzianaServicio bandaServicio = new BandaHertzianaServicio();
        ProvinciaServicio provinciaServicio = new ProvinciaServicio();
        ProgramasServicio programaServicio = new ProgramasServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string nif = Request.QueryString["NIF"];
                var cadena = emisoraServicio.ObtenerUnica(nif);
                var banda = bandaServicio.ObtenerUnica(cadena.IdBandaHertziana);
                var provincia = provinciaServicio.ObtenerUnica(cadena.IdProvincia);
                var programa = programaServicio.ObtenerUnica(cadena.IdPrograma);

                txtNIF.Text = nif;
                txtBanda.Text = cadena.IdBandaHertziana.ToString();
                txtDescripcion.Text = banda.Descripcion;
                txtIdPrograma.Text = cadena.IdPrograma.ToString();
                txtNombre.Text = programa.Nombre;
                txtIdProvincia.Text = cadena.IdProvincia.ToString();
                txtDescripcionProvincia.Text = provincia.Descripcion;
                txtNombreEmisora.Text = cadena.Nombre.ToString();
                txtDireccion.Text = cadena.Direccion.ToString();

                hdfIdCadena.Value = nif;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var emisoraModelo = new EmisorasModelo();
                emisoraModelo.Nif = txtNIF.Text;
                emisoraModelo.Nombre = txtNombre.Text;
                emisoraModelo.Direccion = txtDireccion.Text;
                emisoraModelo.IdBandaHertziana = int.Parse(txtBanda.Text);
                emisoraModelo.IdPrograma = int.Parse(txtIdPrograma.Text);
                emisoraModelo.IdProvincia = int.Parse(txtIdProvincia.Text);
                emisoraServicio.Editar(emisoraModelo);
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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index");
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
    }
}