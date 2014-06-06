using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.CadenaEmisora
{
    public partial class Editar : System.Web.UI.Page
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

                txtIdCadena.Text = idCadena;
                txtNombreCadena.Text = cadena.Nombre;
                txtNifEmisora.Text = nifEmisora;
                txtNombreEmisora.Text = emisora.Nombre;
                txtNifRep.Text = director.NifPersona;
                txtNombreRep.Text = director.Nombres + director.Apellidos;
                rblEsCentral.SelectedValue = cadenaEmisora.EsCentral == true ? "1" : "0";
                    
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            {
                Response.Redirect("Index.aspx", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {


                    var cadenaEmisoraModelo = new CadenaEmisoraModelo();
                    cadenaEmisoraModelo.IdCadena = int.Parse(txtIdCadena.Text);
                    cadenaEmisoraModelo.NifEmisora = txtNifEmisora.Text;
                    cadenaEmisoraModelo.NifPersona = txtNifRep.Text;
                    cadenaEmisoraModelo.EsCentral = rblEsCentral.SelectedValue == "1" ? true : false;

                    cadenaEmisoraServicio.Editar(cadenaEmisoraModelo);

                    Response.Redirect("Index.aspx", true);
            }
            catch (Exception ex)
            {
                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "Ocurrio un error al insertar el registro" + ex.ToString();
                Page.Validators.Add(err);
            }
        }

        protected void txtBusquedaCadena_TextChanged(object sender, EventArgs e)
        {
            var cadenas = cadenaRadioServicio.ObtenerPorBusqueda(txtBusquedaCadena.Text);
            gvCadenas.DataSource = cadenas;
            gvCadenas.DataBind();
        }

        protected void gvCadenas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCadenas.SelectedRow;

            if (cadena.Value == "cadena")
            {
                txtIdCadena.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreCadena.Text = Server.HtmlDecode(row.Cells[1].Text);
            }
            txtBusquedaCadena.Text = "";
        }

        protected void txtBusquedaEmisora_TextChanged(object sender, EventArgs e)
        {
            var emisoras = emisoraServicio.ObtenerPorBusqueda(txtBusquedaEmisora.Text);
            gvEmisorasEmisora.DataSource = emisoras;
            gvEmisorasEmisora.DataBind();
        }

        protected void gvEmisorasEmisora_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEmisorasEmisora.SelectedRow;

            if (emisora.Value == "emisora")
            {
                txtNifEmisora.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreEmisora.Text = Server.HtmlDecode(row.Cells[1].Text);
            }
            txtBusquedaEmisora.Text = "";
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var personas = personaServicio.ObtenerPorBusqueda(txtBusqueda.Text);
            gvPersonas.DataSource = personas;
            gvPersonas.DataBind();
        }

        protected void gvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPersonas.SelectedRow;


            if (persona.Value == "persona")
            {
                txtNifRep.Text = Server.HtmlDecode(row.Cells[0].Text);
                txtNombreRep.Text = Server.HtmlDecode(row.Cells[1].Text);
            }
            txtBusqueda.Text = "";
        }



    }
}