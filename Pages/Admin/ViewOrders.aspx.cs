using System;
using System.Web;
using ADSLIB2020;

namespace LestoCargo.Admin
{
    public partial class ViewOrders : System.Web.UI.Page
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
                string comando = "SELECT Codigo, Nome, Descricao,Data FROM Pedido WHERE Status='Aguardando Cotacao' ORDER BY Codigo ASC";

                //DATATABLE
                System.Data.DataTable tb = new System.Data.DataTable();

                //CONEXAO AO BANCO DE DADOS, ENVIO DOS COMANDOS SQL
                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;

                tb = (System.Data.DataTable)db.Query(comando); 

                Pedido.DataSource = tb;
                Pedido.DataBind();
                tb.Dispose(); 
                Pesquisa.Text = "";
                Limpar.Visible = false;
                Limpar_Busca.Visible = false;
                Responder.Visible = false;
                EnviarMsg.Visible = false;
                editor.Visible = false;
                ControleCotacao.Visible = false;
                this.Master.MasterForm = false;

            }
            catch(Exception ex)
            {
                Erro.Text = "Houve um erro ao carregar os pedidos";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }
        protected void Pedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo.Text = Pedido.SelectedRow.Cells[1].Text;
                
                this.Master.Codigo = Codigo.Text.ToString();
                string comando = "SELECT * FROM Pedido WHERE Codigo=" + Codigo.Text;

                AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                db.ConnectionString = conexao;
                System.Data.DataTable tb = (System.Data.DataTable)db.Query(comando);

                codcot.Text = "Número da cotação: ";
                Nome.Text = "Nome: ";
                DataPedido.Text = "Data do Pedido: ";
                ControleCotacao.Visible = true;

                if (tb.Rows.Count == 1)
                {
                    Nome.Text += tb.Rows[0]["Nome"].ToString();
                    DataPedido.Text += tb.Rows[0]["Data"].ToString();
                    this.Master.MasterObservacao = tb.Rows[0]["Observacao"].ToString();
                    this.Master.MasterNome = tb.Rows[0]["Nome"].ToString();
                    this.Master.MasterEmail = tb.Rows[0]["Email"].ToString();
                    this.Master.MasterTelefone = tb.Rows[0]["Telefone"].ToString();
                    this.Master.MasterComprimento = tb.Rows[0]["Comprimento"].ToString();
                    this.Master.MasterLargura = tb.Rows[0]["Largura"].ToString();
                    this.Master.MasterAltura = tb.Rows[0]["Altura"].ToString();
                    this.Master.MasterPeso = tb.Rows[0]["Peso"].ToString();
                    this.Master.MasterDescricao = tb.Rows[0]["Descricao"].ToString();
                    this.Master.MasterCepColeta = tb.Rows[0]["CEP_Coleta"].ToString();
                    this.Master.MasterCidadeColeta = tb.Rows[0]["Cidade_Coleta"].ToString();
                    this.Master.MasterRuaColeta = tb.Rows[0]["Rua_Coleta"].ToString();
                    this.Master.MasterNumeroColeta = tb.Rows[0]["Numero_Coleta"].ToString();
                    this.Master.MasterBairroColeta = tb.Rows[0]["Bairro_Coleta"].ToString();
                    this.Master.MasterEstadoColeta = tb.Rows[0]["Estado_Coleta"].ToString();
                    this.Master.MasterCepEntrega = tb.Rows[0]["CEP_Entrega"].ToString();
                    this.Master.MasterCidadeEntrega = tb.Rows[0]["Cidade_Entrega"].ToString();
                    this.Master.MasterRuaEntrega = tb.Rows[0]["Rua_Entrega"].ToString();
                    this.Master.MasterNumeroEntrega = tb.Rows[0]["Numero_Entrega"].ToString();
                    this.Master.MasterBairroEntrega = tb.Rows[0]["Bairro_Entrega"].ToString();
                    this.Master.MasterEstadoEntrega = tb.Rows[0]["Estado_Entrega"].ToString();
                    this.Master.MasterForm = true;
                    
                    
                    codcot.Visible = true;
                    Codigo.Visible = true;
                    Limpar.Visible = true;
                    Responder.Visible = true;
                }

            }
            catch(Exception ex)
            {
                Codigo.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Erro.Text = "";
                if (Pesquisa.Text.Trim() == "")
                {
                    Erro.Text = "Insira um valor no campo pesquisa";
                }
                else
                {
                    string comando = "SELECT Codigo,Nome,Descricao FROM Pedido WHERE Status='Aguardando Cotacao' AND Nome + Descricao LIKE '%" + Pesquisa.Text + "%'";

                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    System.Data.DataTable tb = new System.Data.DataTable();
                    tb = (System.Data.DataTable)db.Query(comando);

                    Pedido.DataSource = tb;
                    Pedido.DataBind();
                    Pedido.Dispose();
                    Limpar_Busca.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Erro.Text = "Houve uma falha inesperada";
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
            }
        }

        protected void Limpar_Click(object sender, EventArgs e)
        {
            
            this.Master.MasterForm = false;
            Responder.Text = "Responder";
            ControleCotacao.Visible = false;
            codcot.Visible = false;
            Limpar.Visible = false;
            Responder.Visible = false;
            editor.Visible = false;
            EnviarMsg.Visible = false;
        }

        protected void Limpar_Busca_Click(object sender, EventArgs e)
        {
            RecuperarDados();
            Pesquisa.Text = "";
        }

        protected void Responder_Click(object sender, EventArgs e)
        {
            if (editor.Visible)
            {
                editor.Visible = false;
                EnviarMsg.Visible = false;
                Responder.Text = "Responder";
            }
            else
            {
                editor.Visible = true;
                EnviarMsg.Visible = true;
                Responder.Text = "Fechar Editor";
            }
        }

        protected void EnviarMsg_Click(object sender, EventArgs e)
        {
            try
            {
                if (Resgate.Value == "")
                {
                    Erro.Text = "A mensagem não pode ser vazia";
                }
                else
                {
                    string comando = "UPDATE Pedido SET Status=" + "'Aguardando Resposta'" + ",Atual_Status='" + DateTime.Now.ToString() + "' Where Codigo=" + Codigo.Text;

                    AppDatabase.OleDBTransaction db = new AppDatabase.OleDBTransaction();
                    db.ConnectionString = conexao;
                    db.Query(comando);

                    /*
                    MailMessage email = new MailMessage();
                    SmtpClient smtp = new SmtpClient();

                    email.Subject = "Cotação " + Nome.Text;
                    email.To.Add(Email.Text);
                    MailAddress from = new MailAddress("seuemail@email.com");
                    email.From = from;
                    email.Body = "Olá, " + Nome.Text + "\n";
                    email.Body = Resgate.Value;
                    email.IsBodyHtml = false;

                    // PASSO 2 - ENVIAR A MENSAGEM POR SMTP (SEND EMAIL TRANSFER PROTOCOL)

                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("seuemail@email.com", "suasenha");
                    smtp.Send(email);
                    */

                    Erro.Text = "Mensagem enviada com sucesso.";
                    RecuperarDados();
                }
            }
            catch (Exception ex)
            {
                RecoverExceptions re = new RecoverExceptions();
                re.SaveException(ex);
                Erro.Text = "Houve uma falha inesperada.Por Favor tente mais tarde";

            }
        }
    }
}