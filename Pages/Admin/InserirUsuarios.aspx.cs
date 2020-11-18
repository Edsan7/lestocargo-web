using ADSLIB2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LestoCargo
{
    public partial class InserirUsuarios : System.Web.UI.Page
    {
        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecuperarDados();
            }
            
        }    
        protected void RecuperarDados()
        {
            try
            {
                string comando = "SELECT * FROM Funcionarios ORDER BY Nome ASC";

                System.Data.DataTable tb = new System.Data.DataTable();

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                tb = (System.Data.DataTable)db.Query(comando);

                Funcionarios.DataSource = tb;
                Funcionarios.DataBind();
                Funcionarios.Dispose();

                Codigo.Text = "";
                Nome.Text = "";
                Login.Text = "";
                Senha.Text = "";
                Anotacoes.Text = "";
                Excluir.Visible = false;
                Limpar.Visible = false;
                codfunc.Visible = false;
                Mensagem.Text = "";
            }
            catch(Exception ex)
            {
                Mensagem.Text = "Houve uma falha inesperada. Por Favor, tente novamente mais tarde";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Nome.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Nome";
                }
                else if (Login.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Login";
                }
                else if (Senha.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Senha";
                }
                else if (Anotacoes.Text.Trim() == "")
                {
                    Mensagem.Text = "Preencha o campo Anotações";
                }
                else if (LoginExiste(Login.Text.Trim()) == true)
                {
                    Mensagem.Text = "Este login já existe";
                }
                else
                {
                    string comando = "";
                    if(Codigo.Text == "")
                    {
                        comando = "INSERT INTO Funcionarios(Nome,Login,Senha,Anotacoes) VALUES('" + Nome.Text + "','" + Login.Text + "','" + Senha.Text + "','" + Anotacoes.Text + "');";
                    }
                    else
                    {
                        comando = "UPDATE Funcionarios SET Nome='" + Nome.Text + "',Login='" + Login.Text + "',Senha='" + Senha.Text + "',Anotacoes='"+Anotacoes.Text+"' WHERE Codigo="+Codigo.Text+";";
                    }
                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    db.Query(comando);

                    RecuperarDados();
                }
            }
            catch (Exception ex)
            {
                Mensagem.Text = "Houve uma falha inesperada. Por Favor, tente novamente mais tarde";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }

        }
        protected bool LoginExiste(string nomeLogin)
        {
            string comando = "SELECT * FROM Funcionarios WHERE Login ='" + nomeLogin + "';";

            AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
            db.ConnectionString = conexao;
            System.Data.DataTable tb = (System.Data.DataTable)db.Query(comando);

            if (tb.Rows.Count == 1)
            {
                if (tb.Rows[0]["Codigo"].ToString() == Codigo.Text)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        protected void Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                string comando = "DELETE FROM Funcionarios WHERE Codigo=" + Codigo.Text + ";";

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                db.Query(comando);

                Mensagem.Text = "Registro apagado com sucesso";

                RecuperarDados();

            }
            catch (Exception ex)
            {
                Mensagem.Text = "Houve uma falha inesperada";
                //Instancia a Classe RecoverExceptions
                RecoverExceptions re = new RecoverExceptions();
                //Salva a exceção
                re.SaveException(ex);
            }
        }

        protected void Funcionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo.Text = Funcionarios.SelectedRow.Cells[1].Text;
                string comando = "SELECT * FROM Funcionarios WHERE Codigo=" + Codigo.Text;

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = (System.Data.DataTable)db.Query(comando);

                if (tb.Rows.Count == 1)
                { 
                    Nome.Text = tb.Rows[0]["Nome"].ToString();
                    Login.Text = tb.Rows[0]["Login"].ToString();
                    Senha.Text = tb.Rows[0]["Senha"].ToString();
                    Anotacoes.Text = tb.Rows[0]["Anotacoes"].ToString();
                    Excluir.Visible = true;
                    Limpar.Visible = true;
                    codfunc.Visible = true;

                }
            }
            catch(Exception ex)
            {
                Codigo.Text = "Houve uma falha";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
            
        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            Codigo.Text = "";
            codfunc.Text = "";
            Nome.Text = "";
            Login.Text = "";
            Senha.Text = "";
            Anotacoes.Text = "";
            Limpar.Visible = false;
            Excluir.Visible = false;
        }
    }
}