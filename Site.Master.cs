using System;


namespace LestoCargo
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nome"] != null)
            {
                Nome.Text = "Olá, " + Session["Nome"].ToString();
                dropbtn.Visible = true;
                Login.Visible = false;
                Logout.Visible = true;
            }
            else
            {
                dropbtn.Visible = false;
                Login.Visible = true;
                Logout.Visible = false;
            }
        }
    }
}