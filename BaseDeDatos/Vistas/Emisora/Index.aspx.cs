﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaseDeDatos.Vistas.Emisora
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx", true);
        }
    }
}