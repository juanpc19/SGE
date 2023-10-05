using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldASP_NET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                lblSaludo.Text = $"Hola {txtNombre.Text}";
                error.Text = null;
            } else
            {
                error.Text = "Introduzca un nombre en el campo nombre.";
            }
         
        }
    }
}