using ADSLIB2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LestoCargo
{
    public partial class Login : System.Web.UI.Page
    {
        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Enviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NomeLogin.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Login";
                }
                else if (Senha.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Senha";
                }
                else
                {
                    string comando = "SELECT * FROM Funcionarios WHERE Login='" + NomeLogin.Text + "'AND Senha='" + Senha.Text + "';";

                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    System.Data.DataTable tb = (System.Data.DataTable)db.Query(comando);
                    
                    if(tb.Rows.Count == 1)
                    {
                        Session["Codigo"] = tb.Rows[0]["Codigo"].ToString();
                        Session["Nome"] = tb.Rows[0]["Nome"].ToString();

                        // AUTENTICAÇÃO DE USUARIO

                        FormsAuthentication.Initialize();

                        //Define os dados do ticket de autenticação
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Session["Nome"].ToString(), DateTime.Now, DateTime.Now.AddMinutes(30),
                        false, Session["Nome"].ToString(), FormsAuthentication.FormsCookiePath);

                        // Grava o ticket no cookie de autenticação
                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));

                        // redirecionar para a Dasboard
                        Response.Redirect("~/Pages/Admin/Dashboard.aspx");
                    }
                    else
                    {
                        Mensagem.Text = "Dados Inválidos";
                    }

                }
            }
            catch (ThreadAbortException)
            {
                // IGNORE: this is normal behavior for Redirect method
            }
            catch (Exception ex)
            {
                Mensagem.Text = "Houve uma falha inesperada. Por Favor, tente novamente mais tarde";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
            
        }
    }
}