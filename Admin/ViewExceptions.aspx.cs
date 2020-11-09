using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LestoCargo
{
    public partial class ViewExceptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string caminho = HttpContext.Current.Server.MapPath("~/Admin/Exceptions/Log.txt");
            Lista.Text = System.IO.File.ReadAllText(caminho).Replace("\n","<br>");
        }
    }
}