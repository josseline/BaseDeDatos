using BaseDeDatos.Models;
using BaseDeDatos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Patrocinador
{
    public partial class Crear : System.Web.UI.Page
    {
        PatrocinadoresServicio patrocinadorServicio = new PatrocinadoresServicio();
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
                if (patrocinadorServicio.ExisteNifPatrocinador(txtNif.Text))
                {
                    CustomValidator err = new CustomValidator();
                    err.IsValid = false;
                    err.ErrorMessage = "Ya existe un patrocinador con el nif especificado";
                    Page.Validators.Add(err);
                    return;
                }
                else
                {

                    var patrocinadorModelo = new PatrocinadoresModelo();
                    patrocinadorModelo.NifPatrocinador = txtNif.Text;
                    patrocinadorModelo.Nombre = txtNombre.Text;
                    patrocinadorModelo.Direccion = txtDireccion.Text;
                    patrocinadorServicio.Crear(patrocinadorModelo);
                    Response.Redirect("Index.aspx", true);
                }
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