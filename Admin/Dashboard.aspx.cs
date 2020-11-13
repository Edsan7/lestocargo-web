using System;
using System.Web;
using ADSLIB2020;


namespace LestoCargo.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        static string caminho = HttpContext.Current.Server.MapPath("~/App_Data/LESTOCARGO.accdb");
        string conexao = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminho + ";Persist Security Info=False";
        
        

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if(!IsPostBack)
            {
                DashboardData();
            }*/
        }
        protected void RecuperarDados(string comando)
        {
            try
            {
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;

                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                Pedido.DataSource = tb;
                Pedido.DataBind();
                Pedido.Dispose();
            }
            catch(Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada";
            }
        }

        /*protected void DashboardData()
        {
            try
            {
                string comando = "SELECT COUNT (Codigo) FROM Pedido";

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = new System.Data.DataTable();
                tb = (System.Data.DataTable)db.Query(comando);

                CotFeitas.Text = tb.Rows[0][0].ToString();
                //Aguardando.Text = tb.Rows[1][0].ToString();
                //CotNaoFeitas.Text = tb.Rows[0][2].ToString();


            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada";
            }
        }*/
       
        protected void Ordenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Comando = string.Empty;
                if(Ordenar.SelectedIndex == 0)
                {
                    Pedido.DataSource = null;
                    Pedido.DataBind();
                    Pedido.Dispose();
                }
                else if (Ordenar.SelectedIndex == 1)
                {
                    Comando = "SELECT Codigo,Nome,Descricao FROM Pedido WHERE Status='Cotacao Finalizada' ORDER BY Atual_Status ASC";
                    RecuperarDados(Comando);
                }
                else if (Ordenar.SelectedIndex == 2)
                {
                    Comando = "SELECT Codigo,Nome,Descricao FROM Pedido WHERE Status='Calote' ORDER BY Atual_Status ASC";
                    RecuperarDados(Comando);
                }
                else
                {
                    Comando = "SELECT Codigo,Nome,Descricao FROM Pedido WHERE Status='Cartorio Protocolado' ORDER BY Atual_Status ASC";
                    RecuperarDados(Comando);
                }
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada";
            }
        }
    }
}